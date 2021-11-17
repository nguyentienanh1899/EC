using System;
using System.Collections.Generic;
using System.Text;

namespace EC.CORE.Constants
{
    public class ApplicationConstant
    {
        public const bool ExecuteSuccess = true;
        public const bool ExecuteFailed = false;

        // Pagination constants
        public const int DefaultCurrentPage = 1;
        public const int DefaultDisplayItems = 10;

        public const string USER_CONTENT_FOLDER_NAME = "user-content";

        // User-state constants
        public const string Temporary = "TEMPORARY";
        public const string FirstLogin = "FIRST_LOGIN";
        public const string Locked = "LOCKED";
        public const string Normal = "NORMAL";
        public const string RecordNormalDisplayName = "Normal";
        public const string RecordTemporaryDisplayName = "Temporary";
        public const string RecordFirstLoginDisplayName = "First Login";
        public const string RecordLockedDisplayName = "Locked";

        // DeleteFlag constants
        public const string Deleted = "DELETED";
        public const string Available = "AVAILABLE";
        public const string RecordDeletedDisplayName = "Deleted";
        public const string RecordAvailableDisplayName = "Available";

        public const int NumberOfFeaturedProducts = 4;
        public const int NumberOfLatestProducts = 6;
    }
}
