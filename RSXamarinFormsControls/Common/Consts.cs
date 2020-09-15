using System;

namespace RSXamarinFormsControls
{
    public static class Consts
    {
        public const string CACHEKEY_CARDLIST = "CardList";
        public const string CACHEKEY_MYCARDLIST = "MyCardList";
        public const string CACHEKEY_PERSONLIST = "personList";
        public const string CACHEKEY_PHARMACY = "pharmacy";
        public const string CACHEKEY_SALESCAMPAIGN = "salesCampaign";
        public const string CACHEKEY_DISTRIBUTOR = "distributor";
        public const string CACHEKEY_GEOLOCATION = "geoLocation";
        public const string CACHEKEY_CURRENTUSER = "current_user";
        public const string CACHEKEY_ISLOGGEDOUT = "Is_LoggedOut";
        public const string CACHEKEY_LOOKUPGETALLMOBILE = "LookupGetAllMobile";
        public const string CACHEKEY_VERIFYCODE = "VERIFYCODE";
        public const string CACHEKEY_GETUSERMOBILE = "GetUserMobile";
        public const string CACHEKEY_ACTIVITYLISTDAY = "ActivityList_Day_";
        public const string CACHEKEY_ACTIVITYLISTDAY_F = "ActivityList_Day_{0:yyyyMMdd}";
        public const string CACHEKEY_HOST = "host";
        public const string CACHEKEY_METERED_CONNECTIONS = "metered_connections";
        public const string CACHEKEY_LAST_DATA_SYNC = "last_data_sync";
        public const string CACHEKEY_LAST_RESULT_SYNC = "last_result_sync";
        public const string CACHEKEY_CLM_EXISTDAY = "CLM_ExistDay_";
        public const string CACHEKEY_CLM_EXISTDAY_EMPTY = "CLM_ExistDay_00010101";
        public const string CACHEKEY_CLM_EXISTDAY_F = "CLM_ExistDay_{0:yyyyMMdd}";
        public const string CACHEKEY_CLM_IS_UPDATED = "CLM_Is_Updated";
        public const string CACHEKEY_CLM_MUST_UPDATE_COUNT = "CLM_Must_Updated_Count";
        public const string CACHEKEY_IMPERSONATED = "Impersonate_Action";
        public const string CACHEKEY_APPLICATION_SLEEP = "ApplicationSleep";
        public const string CACHEKEY_APPLICATION_RESUME = "ApplicationResume";
        public const string CACHEKEY_LISTVIEW_APPEARING = "ListViewAppearing";


        public const string REPORT_QUANTITY_KEY = "Q";
        public const string STATUS_ACTIVE = "A";
        public const string STATUS_INACTIVE = "I";
        public const int NEW_RECORD_ID = -99;

        public const int CARD_LIST_DEFAULT_LIMIT = 30;

        public const string EXPENSE_DOC_KIND_CASH = "N";
        public const string EXPENSE_DOC_KIND_CREDIT_CARD = "K";
        public const string EXPENSE_STATUS_WAITING = "U";
        public const string EXPENSE_STATUS_SENT = "P";
        public const string EXPENSE_STATUS_PRE_APPROVAL = "R";
        public const string EXPENSE_STATUS_POST_APPROVED = "O";
        public const string EXPENSE_STATUS_CANCELED = "X";
        public const string EXPENSE_STATUS_ON_ACCOUNTING = "E";
        public const string EXPENSE_STATUS_ALL = "";

        public const string EXPENSE_SELECTED_EXPENSE_PRODUCT = "selectedExpenseProduct";

        public const int ACTIVITYPLAN_DETAILINGKIND_NONE = 0;
        public const int ACTIVITYPLAN_DETAILINGKIND_CLASSIC = 1;
        public const int ACTIVITYPLAN_DETAILINGKIND_DIGITAL = 2;

        public const byte MARKETINGTOOLKIND_GENERAL = 1;
        public const byte MARKETINGTOOLKIND_SPEECH = 2;
        public const byte MARKETINGTOOLKIND_PRESENTATION = 3;

        public const string DEFAULT_HOST = "";
        public const int DEFAULT_PRODUCT_ID = 0;

        public const int BR_ACTIVITYPLANDATEPARTCHECKSENABLED = 11;
        public const int BR_INTEGRATEDSEGMENTATIONENABLED = 25;
        public const int BR_COMPANYSHORTNAME = 42;
        public const int BR_CUSTOMCONFIG = 2001;
        public const int BR_VISITCONFLICTMODE = 7;
        public const int BR_SALESORDERALLOWALLPRODUCT = 53;
        public const int BR_NotOwnedCardVisitAllowed = 25;

        public const int CARDTYPE_DOCTOR = -2;
        public const int CARDTYPE_PHARMACIST = -3;

        public const int RESPUNITTYPE_MSR = 1;
        public const int RESPUNITTYPE_RM = 2;
        public const int RESPUNITTYPE_SM = 5;
        public const int RESPUNITTYPE_BUM = 6;

        public const int NEW_LOCATION_ID = -1;

        public const string DATETIMEPATTERN = "yyyy'-'MM'-'dd'T'HH':'mm':'ss";

        public const string DATE_FORMAT1 = "yyyy-MM-dd";
        public const string DATE_FORMAT2 = "dd-MM-yyyy";
        public const string DATE_FORMAT3 = "dd.MM.yyyy";
        public const string DATE_FORMAT4 = "dd MMMM yyyy";
        public const string DATE_FORMAT5 = "dd MMMM yyyy , dddd";
        public const string PERIOD_FORMAT = "yyyy-MM";

        public const double UWP_TOPCOMMANDBARAREA_FIRST_ROW_HEIGHT = 40;

        public static readonly TimeSpan CLMREPORT_EXPIRATION_TIME = new TimeSpan(1, 0, 0);  ///1 HOUR


        public const string CLM_PRESENTATION_CARD = "Presentation_Card-";
        public const string CLM_PRESENTATION_DATE = "Presentation_Date-";
        public const string CLM_PRESENTATION_DATE_F = "Presentation_Date-{0:yyyy-MM-dd}_";
        public const string CLM_PRESENTATION = "Presentation-";
        //public const string CLM_PRESENTATION_RESULT = "PresentationResult-";
        public const string CLM_PRESENTATION_MEDIA = "PresentationMedia-";
        public const string CLM_PRESENTATION_LONG_TAPPED = "PresentationLongTapped";
        public const string CLM_PRESENTATION_TAPPED = "PresentationTapped";


        public const string SYNC_SETTINGS_SYNC_COMPLETED = "SyncCompleted";
        public const string SYNC_SETTINGS_CLM_SYNCHRONIZED_ERROR = "CLMSynchronizedError";
        public const string SYNC_SETTINGS_CLM_SYNCHRONIZED = "CLMSynchronized";

        public const string CHECK_FOR_CONFLICTING_DATE = "CheckForConflictingDate";

        public const string MAP_CAMERA_POSITION_UPDATING = "Map_CameraPositionUpdating";

        public const string ACTIVITY_POP2 = "POP2";
        public const string ACTIVITY_SELECTED_DUAL_VISIT = "SelectedDualVisit";
        public const string ACTIVITY_POP = "SelectedDualVisit";

        public const string CARD_SHOW_MENU = "ShowMenu";
        public const string CARD_CLOSE_MENU = "CloseMenu";
        public const string CARD_SIZE_ALLOCATED = "SizeAllocated";
        public const string CARD_SELECTED_PROFESSION = "selectedProfession";
        public const string CARD_SELECTED_NEW_LOCATION = "selectedNewLocation";
        public const string CARD_SELECTED_LOCATION = "selectedLocation";
        public const string CARD_OLD_FILTER_SET = "oldFilterSet";
        public const string CARD_SELECTED_LOCATION_BRICK = "selectedLocationBrick";
        public const string CARD_SELECTED_LOCATION_TYPE = "selectedLocationType";
        public const string CARD_FILTER_RULES = "filterRules";
        public const string CARD_INFO_UPDATED = "Card_Info_Updated";

        public const string LOCATION_SELECTED_LOCATION_TYPE = "selectedLocationType";
        public const string LOCATION_SELECTED_LOCATION = "selectedLocation";
        public const string LOCATION_SELECTED_LOCATION_BRICK = "selectedLocationBrick";
        public const string LOCATION_SELECTED_NEW_LOCATION = "selectedNewLocation";

        public const string CHANGING_ONLINE_MOD = "CHANGING_ONLINE_MOD";

        public const string ON_APPEARING = "OnAppearing";
        public const string ON_DISAPPEARING = "OnDisappearing";

        public const string IMPERSONATE_SUCCESS = "ImpersonateSuccess";

        public const string ACTIVITY_VISITTYPE_CODE = "**ZD**";

        internal const string DEFAULT_SETTINGS_KEY_SERVERURL = "serverUrl"; // default setting key.
        internal const string DEFAULT_SETTINGS_KEY_LANGUAGE = "language"; // default setting key.
        internal const string DEFAULT_SETTINGS_KEY_EMPHASIZEPHARMACYNAME = "emphasizePharmacyName"; // default setting key.
        internal const string DEFAULT_SETTINGS_KEY_SKIPSUCCESSFULOPERATIONDIALOGS = "skipSuccessfulOperationDialogs"; // default setting key.
        internal const string DEFAULT_SETTINGS_KEY_SETTINGSFORCED = "settingsForced"; // default setting key.
        internal const string DEFAULT_SETTINGS_KEY_ALLOWCELLULARDATA = "allowCellularData"; // default setting key.       

    }
}
