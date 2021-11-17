using Ardalis.SmartEnum;
using EC.CORE.Constants;

namespace EC.CORE.BaseEnumeration
{
    public abstract class DeleteFlag : SmartEnum<DeleteFlag>
    {
        /// <summary>
        /// Deleted Record
        /// </summary>
        public static readonly DeleteFlag Deleted = new RecordDeletedFlag();

        /// <summary>
        /// Available Record
        /// </summary>
        public static readonly DeleteFlag Available = new RecordAvailableFlag();

        private DeleteFlag(string name, int value) : base(name, value)
        {
        }

        /// <summary>
        /// Display Name
        /// </summary>
        public abstract string DisplayName { get; }

        private sealed class RecordDeletedFlag : DeleteFlag
        {
            public RecordDeletedFlag() : base(ApplicationConstant.Deleted, 1)
            {
            }

            //TODO: Tung-Try to get display by culture
            public override string DisplayName => ApplicationConstant.RecordDeletedDisplayName;
        }

        private sealed class RecordAvailableFlag : DeleteFlag
        {
            public RecordAvailableFlag() : base(ApplicationConstant.Available, 0)
            {
            }

            public override string DisplayName => ApplicationConstant.RecordAvailableDisplayName;
        }
    }
}