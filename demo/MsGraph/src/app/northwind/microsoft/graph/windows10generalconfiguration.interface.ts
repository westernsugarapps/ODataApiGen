import { requiredPasswordType } from './requiredpasswordtype.enum';
import { stateManagementSetting } from './statemanagementsetting.enum';
import { diagnosticDataSubmissionMode } from './diagnosticdatasubmissionmode.enum';
import { edgeCookiePolicy } from './edgecookiepolicy.enum';
import { visibilitySetting } from './visibilitysetting.enum';
import { weeklySchedule } from './weeklyschedule.enum';
import { defenderMonitorFileActivity } from './defendermonitorfileactivity.enum';
import { defenderPromptForSampleSubmission } from './defenderpromptforsamplesubmission.enum';
import { defenderScanType } from './defenderscantype.enum';
import { defenderCloudBlockLevelType } from './defendercloudblockleveltype.enum';
import { windowsStartMenuAppListVisibilityType } from './windowsstartmenuapplistvisibilitytype.enum';
import { windowsStartMenuModeType } from './windowsstartmenumodetype.enum';
import { windowsSpotlightEnablementSettings } from './windowsspotlightenablementsettings.enum';
import { safeSearchFilterType } from './safesearchfiltertype.enum';
import { defenderDetectedMalwareActions } from './defenderdetectedmalwareactions.interface';
import { windows10NetworkProxyServer } from './windows10networkproxyserver.interface';
import { edgeSearchEngineBase } from './edgesearchenginebase.interface';
import { deviceConfiguration } from './deviceconfiguration.interface';

export interface windows10GeneralConfiguration extends deviceConfiguration {
  enterpriseCloudPrintDiscoveryEndPoint: string;
  enterpriseCloudPrintOAuthAuthority: string;
  enterpriseCloudPrintOAuthClientIdentifier: string;
  enterpriseCloudPrintResourceIdentifier: string;
  enterpriseCloudPrintDiscoveryMaxLimit: number;
  enterpriseCloudPrintMopriaDiscoveryResourceIdentifier: string;
  searchBlockDiacritics: boolean;
  searchDisableAutoLanguageDetection: boolean;
  searchDisableIndexingEncryptedItems: boolean;
  searchEnableRemoteQueries: boolean;
  searchDisableIndexerBackoff: boolean;
  searchDisableIndexingRemovableDrive: boolean;
  searchEnableAutomaticIndexSizeManangement: boolean;
  diagnosticsDataSubmissionMode: diagnosticDataSubmissionMode;
  oneDriveDisableFileSync: boolean;
  smartScreenEnableAppInstallControl: boolean;
  personalizationDesktopImageUrl: string;
  personalizationLockScreenImageUrl: string;
  bluetoothAllowedServices: string[];
  bluetoothBlockAdvertising: boolean;
  bluetoothBlockDiscoverableMode: boolean;
  bluetoothBlockPrePairing: boolean;
  edgeBlockAutofill: boolean;
  edgeBlocked: boolean;
  edgeCookiePolicy: edgeCookiePolicy;
  edgeBlockDeveloperTools: boolean;
  edgeBlockSendingDoNotTrackHeader: boolean;
  edgeBlockExtensions: boolean;
  edgeBlockInPrivateBrowsing: boolean;
  edgeBlockJavaScript: boolean;
  edgeBlockPasswordManager: boolean;
  edgeBlockAddressBarDropdown: boolean;
  edgeBlockCompatibilityList: boolean;
  edgeClearBrowsingDataOnExit: boolean;
  edgeAllowStartPagesModification: boolean;
  edgeDisableFirstRunPage: boolean;
  edgeBlockLiveTileDataCollection: boolean;
  edgeSyncFavoritesWithInternetExplorer: boolean;
  cellularBlockDataWhenRoaming: boolean;
  cellularBlockVpn: boolean;
  cellularBlockVpnWhenRoaming: boolean;
  defenderBlockEndUserAccess: boolean;
  defenderDaysBeforeDeletingQuarantinedMalware: number;
  defenderDetectedMalwareActions: defenderDetectedMalwareActions;
  defenderSystemScanSchedule: weeklySchedule;
  defenderFilesAndFoldersToExclude: string[];
  defenderFileExtensionsToExclude: string[];
  defenderScanMaxCpu: number;
  defenderMonitorFileActivity: defenderMonitorFileActivity;
  defenderProcessesToExclude: string[];
  defenderPromptForSampleSubmission: defenderPromptForSampleSubmission;
  defenderRequireBehaviorMonitoring: boolean;
  defenderRequireCloudProtection: boolean;
  defenderRequireNetworkInspectionSystem: boolean;
  defenderRequireRealTimeMonitoring: boolean;
  defenderScanArchiveFiles: boolean;
  defenderScanDownloads: boolean;
  defenderScanNetworkFiles: boolean;
  defenderScanIncomingMail: boolean;
  defenderScanMappedNetworkDrivesDuringFullScan: boolean;
  defenderScanRemovableDrivesDuringFullScan: boolean;
  defenderScanScriptsLoadedInInternetExplorer: boolean;
  defenderSignatureUpdateIntervalInHours: number;
  defenderScanType: defenderScanType;
  defenderScheduledScanTime: any;
  defenderScheduledQuickScanTime: any;
  defenderCloudBlockLevel: defenderCloudBlockLevelType;
  lockScreenAllowTimeoutConfiguration: boolean;
  lockScreenBlockActionCenterNotifications: boolean;
  lockScreenBlockCortana: boolean;
  lockScreenBlockToastNotifications: boolean;
  lockScreenTimeoutInSeconds: number;
  passwordBlockSimple: boolean;
  passwordExpirationDays: number;
  passwordMinimumLength: number;
  passwordMinutesOfInactivityBeforeScreenTimeout: number;
  passwordMinimumCharacterSetCount: number;
  passwordPreviousPasswordBlockCount: number;
  passwordRequired: boolean;
  passwordRequireWhenResumeFromIdleState: boolean;
  passwordRequiredType: requiredPasswordType;
  passwordSignInFailureCountBeforeFactoryReset: number;
  privacyAdvertisingId: stateManagementSetting;
  privacyAutoAcceptPairingAndConsentPrompts: boolean;
  privacyBlockInputPersonalization: boolean;
  startBlockUnpinningAppsFromTaskbar: boolean;
  startMenuAppListVisibility: windowsStartMenuAppListVisibilityType;
  startMenuHideChangeAccountSettings: boolean;
  startMenuHideFrequentlyUsedApps: boolean;
  startMenuHideHibernate: boolean;
  startMenuHideLock: boolean;
  startMenuHidePowerButton: boolean;
  startMenuHideRecentJumpLists: boolean;
  startMenuHideRecentlyAddedApps: boolean;
  startMenuHideRestartOptions: boolean;
  startMenuHideShutDown: boolean;
  startMenuHideSignOut: boolean;
  startMenuHideSleep: boolean;
  startMenuHideSwitchAccount: boolean;
  startMenuHideUserTile: boolean;
  startMenuLayoutEdgeAssetsXml: string;
  startMenuLayoutXml: string;
  startMenuMode: windowsStartMenuModeType;
  startMenuPinnedFolderDocuments: visibilitySetting;
  startMenuPinnedFolderDownloads: visibilitySetting;
  startMenuPinnedFolderFileExplorer: visibilitySetting;
  startMenuPinnedFolderHomeGroup: visibilitySetting;
  startMenuPinnedFolderMusic: visibilitySetting;
  startMenuPinnedFolderNetwork: visibilitySetting;
  startMenuPinnedFolderPersonalFolder: visibilitySetting;
  startMenuPinnedFolderPictures: visibilitySetting;
  startMenuPinnedFolderSettings: visibilitySetting;
  startMenuPinnedFolderVideos: visibilitySetting;
  settingsBlockSettingsApp: boolean;
  settingsBlockSystemPage: boolean;
  settingsBlockDevicesPage: boolean;
  settingsBlockNetworkInternetPage: boolean;
  settingsBlockPersonalizationPage: boolean;
  settingsBlockAccountsPage: boolean;
  settingsBlockTimeLanguagePage: boolean;
  settingsBlockEaseOfAccessPage: boolean;
  settingsBlockPrivacyPage: boolean;
  settingsBlockUpdateSecurityPage: boolean;
  settingsBlockAppsPage: boolean;
  settingsBlockGamingPage: boolean;
  windowsSpotlightBlockConsumerSpecificFeatures: boolean;
  windowsSpotlightBlocked: boolean;
  windowsSpotlightBlockOnActionCenter: boolean;
  windowsSpotlightBlockTailoredExperiences: boolean;
  windowsSpotlightBlockThirdPartyNotifications: boolean;
  windowsSpotlightBlockWelcomeExperience: boolean;
  windowsSpotlightBlockWindowsTips: boolean;
  windowsSpotlightConfigureOnLockScreen: windowsSpotlightEnablementSettings;
  networkProxyApplySettingsDeviceWide: boolean;
  networkProxyDisableAutoDetect: boolean;
  networkProxyAutomaticConfigurationUrl: string;
  networkProxyServer: windows10NetworkProxyServer;
  accountsBlockAddingNonMicrosoftAccountEmail: boolean;
  antiTheftModeBlocked: boolean;
  bluetoothBlocked: boolean;
  cameraBlocked: boolean;
  connectedDevicesServiceBlocked: boolean;
  certificatesBlockManualRootCertificateInstallation: boolean;
  copyPasteBlocked: boolean;
  cortanaBlocked: boolean;
  deviceManagementBlockFactoryResetOnMobile: boolean;
  deviceManagementBlockManualUnenroll: boolean;
  safeSearchFilter: safeSearchFilterType;
  edgeBlockPopups: boolean;
  edgeBlockSearchSuggestions: boolean;
  edgeBlockSendingIntranetTrafficToInternetExplorer: boolean;
  edgeSendIntranetTrafficToInternetExplorer: boolean;
  edgeRequireSmartScreen: boolean;
  edgeEnterpriseModeSiteListLocation: string;
  edgeFirstRunUrl: string;
  edgeSearchEngine: edgeSearchEngineBase;
  edgeHomepageUrls: string[];
  edgeBlockAccessToAboutFlags: boolean;
  smartScreenBlockPromptOverride: boolean;
  smartScreenBlockPromptOverrideForFiles: boolean;
  webRtcBlockLocalhostIpAddress: boolean;
  internetSharingBlocked: boolean;
  settingsBlockAddProvisioningPackage: boolean;
  settingsBlockRemoveProvisioningPackage: boolean;
  settingsBlockChangeSystemTime: boolean;
  settingsBlockEditDeviceName: boolean;
  settingsBlockChangeRegion: boolean;
  settingsBlockChangeLanguage: boolean;
  settingsBlockChangePowerSleep: boolean;
  locationServicesBlocked: boolean;
  microsoftAccountBlocked: boolean;
  microsoftAccountBlockSettingsSync: boolean;
  nfcBlocked: boolean;
  resetProtectionModeBlocked: boolean;
  screenCaptureBlocked: boolean;
  storageBlockRemovableStorage: boolean;
  storageRequireMobileDeviceEncryption: boolean;
  usbBlocked: boolean;
  voiceRecordingBlocked: boolean;
  wiFiBlockAutomaticConnectHotspots: boolean;
  wiFiBlocked: boolean;
  wiFiBlockManualConfiguration: boolean;
  wiFiScanInterval: number;
  wirelessDisplayBlockProjectionToThisDevice: boolean;
  wirelessDisplayBlockUserInputFromReceiver: boolean;
  wirelessDisplayRequirePinForPairing: boolean;
  windowsStoreBlocked: boolean;
  appsAllowTrustedAppsSideloading: stateManagementSetting;
  windowsStoreBlockAutoUpdate: boolean;
  developerUnlockSetting: stateManagementSetting;
  sharedUserAppDataAllowed: boolean;
  appsBlockWindowsStoreOriginatedApps: boolean;
  windowsStoreEnablePrivateStoreOnly: boolean;
  storageRestrictAppDataToSystemVolume: boolean;
  storageRestrictAppInstallToSystemVolume: boolean;
  gameDvrBlocked: boolean;
  experienceBlockDeviceDiscovery: boolean;
  experienceBlockErrorDialogWhenNoSIM: boolean;
  experienceBlockTaskSwitcher: boolean;
  logonBlockFastUserSwitching: boolean;
  tenantLockdownRequireNetworkDuringOutOfBoxExperience: boolean
}