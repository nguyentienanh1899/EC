namespace EC.CORE.Message
{
    public class ApplicationMessage
    {
        #region ERROR MESSAGE

        /// <summary>
        /// The required message
        /// </summary>
        public const string E0001 = "{0} is required.";

        /// <summary>
        /// The incorrect login info message
        /// </summary>
        public const string E0002 = "Username or password is incorrect.";

        #endregion ERROR MESSAGE

        #region MESSAGE NORMAL

        public const string M0001 = "Success";

        #endregion MESSAGE NORMAL
    }
}