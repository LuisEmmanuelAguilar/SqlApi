namespace SqlApi.AsyncService.Common.Models
{
    /// <summary>
    /// These values have been mapped from RE7 and FE7 in order to implement formatting logic
    /// that parallels the functionality of those products.
    /// </summary>
    public enum LegacyFormatDescriptor
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        None = 0,
        Alpha,
        Amount,
        Number,
        Boolean,
        DateMDY,
        Memo,
        TableEntry,
        StaticEntry,
        AccountId,
        ConsAccountId,
        TimeInterval,
        DateMMDD,
        DateMMYYYY,
        AmountNoCurrency,
        AmountNegative,
        NumberFormatted,
        AmountNegativeNoCurrency,
        AmountThreeDecimal,
        AmountNegativeThreeDecimal,
        NumberDecimal,
        Rate,
        RateNoMax,
        PercentNonnegative,
        Phone,
        Time,
        ZipCode,
        ZipCodeAlpha,
        SSN,
        Fund,
        Appeal,
        Campaign,
        NumberNegative,
        DateFuzzy,
        StaticLocalEntry,
        State,
        NumberDefaultZero,
        UserName,
        Package,
        ConstituentRecordId, //when id can be entered by f7 for constituent search
        GPA,
        ClassOf,
        AmountAllowZero,
        DPC,
        LOT,
        TransitRouting, //USA only
        SortCode, //UK only
        BSB, //Australia only
        InstitutionId, //Canada only
        BankNumber, //New Zealand only
        RatingSystemCategory,
        DateTime,
        AnnualRate,
        Encrypted,
        DPCUK,
        DPCAUSNZ,
        Binary,
        AlphaUpper,
        StaticEntryBitmask,
        NumberAllowZero,
        NumberThreeDecimalCutZeros,
        Year,
        EncryptedDES,
        StaticLocalEntryAlpha, // indicates that the ID is alphanumeric rather than numeric
        BooleanAlpha, // for a Boolean saved to the database as 'Y' or 'N'
        MD5,
        Numeric, //[SJP] for numbers upto 19 digits e.g. FinderNumber Bullseye
        DateFuzzyMMDD,
        #region FE
        ProjectId = 79,
        AmountFormatZero = 100,
        AmountNegativeFormatZero = 101,
        NumberZero = 104,
        AmountNoCurrencyFormatZero = 105,
        PercentNonnegativeFourDecimal = 106,
        NumberNoMax = 107,
        RateFourDecimal = 111,
        DateYY = 112,
        DateYYYY = 113,
        DateMDYHHMM = 115,
        DocNum = 116,
        UserPassword = 117,
        UserSalt = 118,
        PIIDate = 119,
        RateId = 36865,
        PoolId = 36866,
        NumberDecimalUpTo5 = 40961,
        EmployeeId = 40962,
        NumberThreeDecimalFormatZero = 40963,
        PercentNonnegativeFiveDecimal = 40964,
        NumberDecimalUpTo7FormatZero = 40965,
        AmountUpTo5FormatZero = 40966,
        RateFourDecimalFormatZero = 40967,
        AmountUpTo5 = 40968,
        NumberDecimalUpTo7 = 40969,
        AmountUpTo4 = 40970,
        AmountUpTo6 = 40971,
        AmountFiveDecimal = 40972,
        CDFA = 49153,
        DESEncrypted = 49154,
        CreditCard = 49155,
        AccountNumber = 49156,
        TaxIdNumber = 49157,
        ReferenceNumber = 49158,
        RoutingNumUS = 49159,
        RoutingNumAU = 49160,
        RoutingNumNZ = 49161,
        RoutingNumCN = 49162,
        Password = 49164,
        MedicalEncryptedText = 49165,
        MedicalEncryptedMemo = 49166,
        #endregion

        #region Custom for back-end only
        Age = -1
        #endregion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
