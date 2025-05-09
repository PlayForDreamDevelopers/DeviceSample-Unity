using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YVR.Core;
using YVR.Enterprise.Device;

namespace YVR.Enterprise.Device.Sample
{ 
    public class AppControl : MonoBehaviour
    {
        struct AppListItem
        {
            public string packageName;
            public string className;
            public string label;
            public bool systemApp;
        }

        public GameObject appListItemPrefab;
        public Transform appPackageItemContainer;
        public Button refreshAllPackagesButton;
        private List<PackageItem> m_AllAppPackageItems = new List<PackageItem>();
        
        public TMP_InputField setBootAutoStartInput;
        public Button setBootAutoStartButton;
        public TMP_Text setBootAutoStartAppList;
        public Button refreshBootAutoStartAppButton;
        
        public Button refreshAppListButton;
        public Transform appListItemContainer;
        public TMP_Text appListCount;
        public TMP_InputField appListPackageNameInput;
        public Button appNameSearchButton;
        public TMP_Text appListPackageName;
        public TMP_Text appListClassName;
        public TMP_Text appListLabel;
        public TMP_Text appListSystemApp;
        public Button launchSearchApp;
        private Dictionary<string, AppListItem> m_AppListItemDictionary = new Dictionary<string, AppListItem>();
        private List<PackageItem> m_AllAppListItems = new List<PackageItem>();
        private string m_CurrentSelectPackageName;
        

        public TMP_InputField startActivityPkgInput;
        public TMP_InputField startActivityClassInput;
        public Button startButton;
        public TMP_InputField stopPackageNameInput;
        public Button stopAppButton;
        
        public TMP_InputField stopPackagesNameInput;
        public Button stopAppsButton;
        
        public TMP_InputField searchAppKeepAlivePackageNameInput;
        public Button searchAppKeepAlivePackageNameButton;
        public TMP_Text currentAppKeepAlivePackageSearchResult;
        public TMP_Text currentAppKeepAlivePackageSearchState;
        public Toggle currentAppKeepAlivePackageSearchToggle;
        
        public TMP_InputField installApkPathInput;
        public Button installApkPathButton;
        public TMP_Text installResult;
        public TMP_InputField uninstallApkPackageNameInput;
        public Button uninstallApkPathButton;
        public TMP_Text unInstallResult;

        public Transform runningThirdPartyAppPackageItemContainer;
        public Button refreshRunningThirdPartyAppPackageName;
        private List<PackageItem> m_RunningThirdPartyAppPackageItems = new List<PackageItem>();

        public TMP_Text topRunningAppForMainDisplayResult;
        public Button getTopRunningAppForMainDisplayButton;
        public TMP_Text TopRunningAppResult;
        public Button getTopRunningAppButton;
        
        public Button startWifiUIButton;
        public Button startBtUIButton;
        
        void Start()
        {
            YVRManager.instance.hmdManager.SetPassthrough(true);
            RefreshAllPackages();
            refreshAllPackagesButton.onClick.AddListener(RefreshAllPackages);
            
            setBootAutoStartButton.onClick.AddListener(SetBootAutoStartApp);
            refreshBootAutoStartAppButton.onClick.AddListener(RefreshAllBootAutoStartAppList);
            
            RefreshAppList();
            refreshAppListButton.onClick.AddListener(RefreshAppList);
            appNameSearchButton.onClick.AddListener(SearchAppInfo);
            launchSearchApp.onClick.AddListener(LaunchSearchApp);
            startButton.onClick.AddListener(StartApp);
            
            stopAppButton.onClick.AddListener(StopApp);
            stopAppsButton.onClick.AddListener(StopApps);
            
            searchAppKeepAlivePackageNameButton.onClick.AddListener(SearchAppKeepAlivePackageName);
            currentAppKeepAlivePackageSearchToggle.onValueChanged.AddListener(SetAppKeepAlivePackageName);
            
            installApkPathButton.onClick.AddListener(InstallApk);
            uninstallApkPathButton.onClick.AddListener(UninstallApk);

            RefreshRunningThirdPartyAppPackageName();
            refreshRunningThirdPartyAppPackageName.onClick.AddListener(RefreshRunningThirdPartyAppPackageName);
            
            getTopRunningAppForMainDisplayButton.onClick.AddListener(GetTopRunningAppForMainDisplay);
            getTopRunningAppButton.onClick.AddListener(GetTopRunningApp);
            
            startWifiUIButton.onClick.AddListener(StartWifiUI);
            startBtUIButton.onClick.AddListener(StartBtUI);
        }

        private void StartBtUI()
        {
            AppMgr.instance.StartBtUI();
        }

        private void StartWifiUI()
        {
            AppMgr.instance.StartWifiUI();
        }

        private void GetTopRunningApp()
        {
            TopRunningAppResult.text = AppMgr.instance.topRunningApp;
        }

        private void GetTopRunningAppForMainDisplay()
        {
            topRunningAppForMainDisplayResult.text = AppMgr.instance.topRunningAppForMainDisplay;
        }

        private void RefreshRunningThirdPartyAppPackageName()
        {
            RemoveAllPackages();
            List<string> packageNameList = AppMgr.instance.runningThirdPartyAppPackageName;
            for (int i = 0; i < packageNameList.Count; i++)
            {
                PackageItem packageItem = Instantiate(appListItemPrefab, runningThirdPartyAppPackageItemContainer,false).GetComponent<PackageItem>();
                m_RunningThirdPartyAppPackageItems.Add(packageItem);
                packageItem.PackageName.text = packageNameList[i];
            }
            
            void RemoveAllPackages()
            {
                if (m_RunningThirdPartyAppPackageItems != null)
                {
                    for (int i = 0; i < m_RunningThirdPartyAppPackageItems.Count; i++)
                    {
                        Destroy(m_RunningThirdPartyAppPackageItems[i].gameObject);
                    }
                    m_RunningThirdPartyAppPackageItems.Clear();
                }
            }
        }
        private void UninstallApk()
        {
            HandleUnInstall(uninstallApkPackageNameInput.text, (result) =>
            {
                string[] results = result.Split('/');
                unInstallResult.text = results[1];
            });
            void HandleUnInstall(string apkPackageName,Action<string> callback = null)
            {
                AppMgr.instance.SilentUnInstall(apkPackageName,callback);
            }
        }

        private void InstallApk()
        {
            HandleInstallApK(installApkPathInput.text, (result) =>
            {
                string[] results = result.Split('/');
                installResult.text = results[1];
            });
            void HandleInstallApK(string apkPath,Action<string> callback = null)
            {
                AppMgr.instance.SilentInstall(apkPath,callback);
            }
        }

        private void SetAppKeepAlivePackageName(bool value)
        {
            HandleSetAppKeepAlivePackageName(searchAppKeepAlivePackageNameInput.text);
            void HandleSetAppKeepAlivePackageName(string packageName)
            {
                if (m_AppListItemDictionary.ContainsKey(packageName))
                {
                    AppMgr.instance.SetAppKeepAlive(packageName, value);
                    currentAppKeepAlivePackageSearchState.text = AppMgr.instance.IsAppKeepAlive(packageName)?"true":"false";
                }
            }
        }

        private void SearchAppKeepAlivePackageName()
        {
            HandleSearchAppKeepAlivePackageName(searchAppKeepAlivePackageNameInput.text);
            
            void HandleSearchAppKeepAlivePackageName(string packageName)
            {
                if (m_AppListItemDictionary.ContainsKey(packageName))
                {
                    currentAppKeepAlivePackageSearchResult.text = packageName;
                    currentAppKeepAlivePackageSearchState.text = AppMgr.instance.IsAppKeepAlive(packageName)?"true":"false";
                }
                else
                {
                    currentAppKeepAlivePackageSearchResult.text = "";
                    currentAppKeepAlivePackageSearchState.text = "";
                    currentAppKeepAlivePackageSearchToggle.isOn = false;
                }
            }
        }

        private void StopApps()
        {
            HandleStopApps(stopPackagesNameInput.text);
            
            void HandleStopApps(string packagesName)
            {
                string[] packages = packagesName.Split(',');
                for (int i = 0; i < packages.Length; i++)
                {
                    Debug.Log(packages[i]);
                }
                AppMgr.instance.StopApps(packages);
            }
        }
        private void StopApp()
        {
            HandleStopApp(stopPackageNameInput.text);
            void HandleStopApp(string pkgName)
            {
                AppMgr.instance.StopApp(pkgName);
            }
        }
        private void LaunchSearchApp()
        {
            HandleStartApp(m_CurrentSelectPackageName,m_AppListItemDictionary[m_CurrentSelectPackageName].className);
        }

        private void StartApp()
        {
            HandleStartApp(startActivityPkgInput.text, startActivityClassInput.text);
        }

        private void HandleStartApp(string pkgName, string className)
        {
            AppMgr.instance.StartActivity(pkgName, className);
        }
        private void RefreshAllBootAutoStartAppList()
        {
            //Note: If there is no startup item, the corresponding array will not be obtained, and it will be empty
            for (int i = 0; i < AppMgr.instance.bootAutoStart.Length; i++)
            {
                setBootAutoStartAppList.text += AppMgr.instance.bootAutoStart[i];
                setBootAutoStartAppList.text += "\n";
            }
        }

        private void SetBootAutoStartApp()
        {
            AppMgr.instance.SetBootAutoStart(setBootAutoStartInput.text);
        }
        private void SearchAppInfo()
        {
            HandleSearchAppInfo(appListPackageNameInput.text);
        }
        
        public void HandleSearchAppInfo(string packageName)
        {
            if (m_AppListItemDictionary != null && m_AppListItemDictionary.TryGetValue(packageName, out AppListItem appListItem))
            {
                m_CurrentSelectPackageName = packageName;
                appListPackageName.text = appListItem.packageName;
                appListClassName.text = appListItem.className;
                appListLabel.text = appListItem.label;
                appListSystemApp.text = appListItem.systemApp.ToString();
            }
        }
        private void RefreshAllPackages()
        {
            RemoveAllPackages();
            List<string> packageNameList = AppMgr.instance.allPackages;
            for (int i = 0; i < packageNameList.Count; i++)
            {
                PackageItem packageItem = Instantiate(appListItemPrefab, appPackageItemContainer,false).GetComponent<PackageItem>();
                m_AllAppPackageItems.Add(packageItem);
                packageItem.PackageName.text = packageNameList[i];
            }
            
            void RemoveAllPackages()
            {
                if (m_AllAppPackageItems != null)
                {
                    for (int i = 0; i < m_AllAppPackageItems.Count; i++)
                    {
                        Destroy(m_AllAppPackageItems[i].gameObject);
                    }
                    m_AllAppPackageItems.Clear();
                }
            }
        }
        public void RefreshAppList()
        {
            RemoveAppList();
            List<string> appListJson = AppMgr.instance.appList;
            appListCount.text = appListJson.Count.ToString();
            for (int i = 0; i < appListJson.Count; i++)
            {
                AppListItem appItem = JsonUtility.FromJson<AppListItem>(appListJson[i]);
                m_AppListItemDictionary.Add(appItem.packageName, appItem);
                PackageItem packageItem = Instantiate(appListItemPrefab, appListItemContainer,false).GetComponent<PackageItem>();
                packageItem.PackageName.text = appItem.packageName;
                m_AllAppListItems.Add(packageItem);
            }
            
            void RemoveAppList()
            {
                if (m_AllAppListItems != null)
                {
                    for (int i = 0; i < m_AllAppListItems.Count; i++)
                    {
                        Destroy(m_AllAppListItems[i].gameObject);
                    }
                    m_AllAppListItems.Clear();
                    m_AppListItemDictionary.Clear();
                }
            }
        }
            
    }
}

