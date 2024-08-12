#pragma warning disable // Disable all warnings
namespace Company.Permissions.Resolver.PermissionFlags.Analysis.Financial
{
    public enum Dashboards
    {
        View = 12,

        AddEdit = 13,

        Delete = 14,
    }

    public enum Insights
    {
        AddEdit = 10,

        Delete = 11,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Employeegivingadministration.EMPLOYEEGIVING.Administration
{
    public enum Donations
    {
        Manage = 24,
    }

    public enum Givingsettings
    {
        Manage = 23,
    }

    public enum Matches
    {
        Manage = 25,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Analysis.Fundraising
{
    public enum Insights
    {
        AddEdit = 5,

        Delete = 6,
    }

    public enum Dashboards
    {
        View = 7,

        AddEdit = 8,

        Delete = 9,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.Security
{
    public enum Users
    {
        View = 15,

        AddEdit = 16,

        MarkInactive = 17,
    }

    public enum Roles
    {
        View = 18,

        AddEdit = 19,

        MarkInactive = 20,

        Delete = 21,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Marketing.Email
{
    public enum Email
    {
        Access = 4,
    }

    public enum Transactionalemail
    {
        Access = 512,
    }

    public enum Simpleemail
    {
        Access = 684,
    }

    public enum Communicationhistory
    {
        Access = 1210,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Grantmaking.Contact
{
    public enum Contacts
    {
        View = 36,

        AddEdit = 37,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Events.Auctions
{
    public enum Auctions
    {
        Manage = 28,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.Datahealth
{
    public enum Datahealthservices
    {
        View = 27,

        Manage = 94,
    }

    public enum Duplicatemanagement
    {
        View = 44,

        Manage = 45,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Employeegivinghome.EMPLOYEEGIVING.Home
{
    public enum Donations
    {
        Make = 26,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Financial.Analyze
{
    public enum Subledgerdashboards
    {
        Payables = 55,

        Receivables = 56,

        Development = 62,
    }

    public enum Generalledgerdashboards
    {
        Accounts = 46,

        Netassets = 47,

        Projects = 48,

        Projectincomeandexpenses = 49,

        Transactioncode1 = 50,

        Transactioncode2 = 51,

        Transactioncode3 = 52,

        Transactioncode4 = 53,

        Transactioncode5 = 54,
    }

    public enum Managementdashboards
    {
        Historyofchanges = 57,

        Metrics = 58,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Grantmaking.Organization
{
    public enum Organizations
    {
        View = 42,

        AddEdit = 43,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Allocations.Statisticalunits
{
    public enum Unittypes
    {
        View = 29,

        Add = 30,

        Edit = 31,
    }

    public enum Unitcounts
    {
        View = 32,

        Add = 33,

        Edit = 34,

        Delete = 35,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Grantmaking.Grant
{
    public enum Grants
    {
        View = 22,

        Edit = 38,

        Approve = 39,

        Decline = 40,

        Reverttopending = 41,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Marketing.Social
{
    public enum SocialAccounts
    {
        Connect = 92,
    }

    public enum SocialPosts
    {
        Create = 88,

        Edit = 89,

        Delete = 90,

        Send = 91,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Events.Eventmanagement
{
    public enum Publiccalendarevents
    {
        AddEdit = 1067,
    }

    public enum Participants
    {
        View = 80,

        Add = 81,

        Edit = 82,
    }

    public enum Checkinclasses
    {
        View = 865,

        AddEdit = 866,

        Delete = 867,
    }

    public enum Events
    {
        View = 77,

        Add = 78,

        Edit = 79,
    }

    public enum Settings
    {
        View = 863,

        AddEdit = 864,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundraising.Workflowdesigner
{
    public enum Actionworkflows
    {
        Apply = 70,
    }

    public enum Workflows
    {
        View = 67,

        AddEdit = 68,

        Delete = 69,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundraising.Opportunities
{
    public enum Opportunitiestabs
    {
        Workopportunities = 132,

        Listsopportunities = 133,

        Analyzeopportunities = 134,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundraising.Attachment
{
    public enum Appealattachments
    {
        View = 120,

        AddEdit = 121,

        Delete = 122,
    }

    public enum Fundattachments
    {
        View = 126,

        AddEdit = 127,

        Delete = 128,
    }

    public enum Campaignattachments
    {
        View = 123,

        AddEdit = 124,

        Delete = 125,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundraising.Analyze
{
    public enum Campaigns
    {
        View = 104,
    }

    public enum Acquisition
    {
        View = 108,
    }

    public enum Actions
    {
        View = 110,
    }

    public enum Funds
    {
        View = 105,
    }

    public enum Appeals
    {
        View = 106,
    }

    public enum Overview
    {
        View = 103,
    }

    public enum Recapture
    {
        View = 109,
    }

    public enum Retention
    {
        View = 107,
    }

    public enum Benchmarking
    {
        View = 180,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundraising.Lists
{
    public enum Actions
    {
        View = 139,
    }

    public enum Constituents
    {
        View = 140,
    }

    public enum Export
    {
        Allow = 142,
    }

    public enum Gifts
    {
        View = 141,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Grantmaking.Application
{
    public enum Applications
    {
        Consider = 156,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Payments.SKYAPI
{
    public enum Endpointaccess
    {
        All = 162,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundraising.Work
{
    public enum Export
    {
        Allow = 154,
    }

    public enum Unassigned
    {
        View = 152,
    }

    public enum Changefundraiser
    {
        Allow = 153,
    }

    public enum Actions
    {
        View = 151,
    }

    public enum Portfolio
    {
        View = 149,
    }

    public enum Gifts
    {
        View = 150,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.SafeChildCheckIn.RENXT.SafeChildCheckIn
{
    public enum Operatecheckin
    {
        Enable = 159,
    }

    public enum Configurecheckin
    {
        Enable = 160,
    }

    public enum Emailclasses
    {
        Enable = 1019,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.ChurchManagement.RENXT.ChurchManagement
{
    public enum Directory
    {
        View = 171,

        Modify = 172,
    }

    public enum Locations
    {
        View = 177,

        Modify = 178,
    }

    public enum EventsandServices
    {
        View = 173,

        Modify = 174,
    }

    public enum Groups
    {
        View = 175,

        Modify = 176,
    }

    public enum PrayerRequests
    {
        View = 1005,

        Modify = 1006,
    }

    public enum Faithjourney
    {
        View = 1071,

        Modify = 1072,
    }

    public enum Churchmembership
    {
        View = 1069,

        Modify = 1070,
    }

    public enum Congregationsummary
    {
        View = 1085,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.ChurchCongregant.RENXT.ChurchCongregant
{
    public enum Congregant
    {
        Access = 182,
    }

    public enum Smallgroupleader
    {
        Access = 194,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Allocations.Allocations
{
    public enum Allocations
    {
        View = 188,

        Add = 189,

        Edit = 190,

        Delete = 191,

        Run = 192,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Generalledger.Spendingpolicies
{
    public enum Spendingpolicies
    {
        View = 201,

        Add = 202,

        Edit = 203,

        Delete = 204,

        Calculate = 205,

        Adjustamounts = 206,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.GRANTMAKING.Security
{
    public enum Users
    {
        View = 214,

        AddEdit = 215,

        MarkInactive = 216,
    }

    public enum Roles
    {
        View = 217,

        AddEdit = 218,

        MarkInactive = 219,

        Delete = 220,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.RENXT.Security
{
    public enum Users
    {
        View = 228,

        AddEdit = 229,

        MarkInactive = 230,
    }

    public enum Roles
    {
        View = 231,

        AddEdit = 232,

        MarkInactive = 233,

        Delete = 234,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.FENXT.Security
{
    public enum Roles
    {
        View = 245,

        AddEdit = 246,

        MarkInactive = 247,

        Delete = 248,
    }

    public enum Users
    {
        View = 242,

        AddEdit = 243,

        MarkInactive = 244,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.EMPLOYEEGIVING.Security
{
    public enum Users
    {
        View = 256,

        AddEdit = 257,

        MarkInactive = 258,
    }

    public enum Roles
    {
        View = 259,

        AddEdit = 260,

        MarkInactive = 261,

        Delete = 262,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Grantmaking.Grantpayments
{
    public enum Grantpayments
    {
        View = 263,

        AddEdit = 264,

        Delete = 525,

        Changestatus = 526,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Volunteers.Volunteermanagement
{
    public enum Positionsandrequirements
    {
        View = 533,

        AddEdit = 534,
    }

    public enum Volunteers
    {
        View = 266,

        AddEdit = 531,

        Verifyrequirements = 532,
    }

    public enum Volunteeropportunities
    {
        View = 515,

        AddEdit = 516,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Volunteers.RENXT.Volunteermanagement
{
    public enum Volunteers
    {
        View = 268,

        AddEdit = 539,

        Verifyrequirements = 540,
    }

    public enum Volunteeropportunities
    {
        View = 519,

        AddEdit = 520,
    }

    public enum Positionsandrequirements
    {
        View = 541,

        AddEdit = 542,
    }

    public enum Emailvolunteers
    {
        AddEdit = 1073,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Allocations.FENXT.Allocations
{
    public enum Allocations
    {
        View = 288,

        Add = 289,

        Edit = 290,

        Delete = 291,

        Run = 292,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Allocations.FENXT.Statisticalunits
{
    public enum Unitcounts
    {
        View = 279,

        Add = 280,

        Edit = 281,

        Delete = 282,
    }

    public enum Unittypes
    {
        View = 276,

        Add = 277,

        Edit = 278,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Marketing.RENXT.Email
{
    public enum Communicationhistory
    {
        Access = 1211,
    }

    public enum Email
    {
        Access = 336,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.LO.Security
{
    public enum Users
    {
        View = 328,

        AddEdit = 329,

        MarkInactive = 330,
    }

    public enum Roles
    {
        View = 331,

        AddEdit = 332,

        MarkInactive = 333,

        Delete = 334,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Marketing.LO.Email
{
    public enum Email
    {
        Access = 338,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Financial.FENXT.Analyze
{
    public enum Managementdashboards
    {
        Historyofchanges = 319,

        Metrics = 320,
    }

    public enum Generalledgerdashboards
    {
        Accounts = 307,

        Netassets = 308,

        Projects = 309,

        Projectincomeandexpenses = 310,

        Transactioncode1 = 311,

        Transactioncode2 = 312,

        Transactioncode3 = 313,

        Transactioncode4 = 314,

        Transactioncode5 = 315,
    }

    public enum Subledgerdashboards
    {
        Payables = 316,

        Receivables = 317,

        Development = 318,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Marketing.LO.Social
{
    public enum SocialPosts
    {
        Create = 354,

        Edit = 355,

        Delete = 356,

        Send = 357,
    }

    public enum SocialAccounts
    {
        Connect = 358,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Marketing.RENXT.Social
{
    public enum SocialPosts
    {
        Create = 344,

        Edit = 345,

        Delete = 346,

        Send = 347,
    }

    public enum SocialAccounts
    {
        Connect = 348,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Analysis.RENXT.Fundraising
{
    public enum Insights
    {
        AddEdit = 364,

        Delete = 365,
    }

    public enum Dashboards
    {
        View = 366,

        AddEdit = 367,

        Delete = 368,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Analysis.FENXT.Financial
{
    public enum Dashboards
    {
        View = 376,

        AddEdit = 377,

        Delete = 378,
    }

    public enum Insights
    {
        AddEdit = 374,

        Delete = 375,
    }

    public enum Lists
    {
        View = 2945,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Events.RENXT.Eventmanagement
{
    public enum Publiccalendarevents
    {
        AddEdit = 1068,
    }

    public enum Participants
    {
        View = 388,

        AddEdit = 390,
    }

    public enum Onlineregistrationforms
    {
        View = 523,

        AddEdit = 524,
    }

    public enum Checkinclasses
    {
        View = 870,

        AddEdit = 871,

        Delete = 872,
    }

    public enum Events
    {
        View = 385,

        AddEdit = 387,
    }

    public enum Settings
    {
        View = 868,

        AddEdit = 869,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundraising.RENXT.Attachment
{
    public enum Appealattachments
    {
        View = 400,

        AddEdit = 401,

        Delete = 402,
    }

    public enum Campaignattachments
    {
        View = 403,

        AddEdit = 404,

        Delete = 405,
    }

    public enum Fundattachments
    {
        View = 406,

        AddEdit = 407,

        Delete = 408,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundraising.RENXT.Analyze
{
    public enum Overview
    {
        View = 418,
    }

    public enum Campaigns
    {
        View = 419,
    }

    public enum Funds
    {
        View = 420,
    }

    public enum Appeals
    {
        View = 421,
    }

    public enum Retention
    {
        View = 422,
    }

    public enum Acquisition
    {
        View = 423,
    }

    public enum Recapture
    {
        View = 424,
    }

    public enum Actions
    {
        View = 425,
    }

    public enum Benchmarking
    {
        View = 426,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundraising.Auctions
{
    public enum Auctions
    {
        Access = 441,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundraising.RENXT.Lists
{
    public enum Actions
    {
        View = 431,
    }

    public enum Constituents
    {
        View = 432,
    }

    public enum Gifts
    {
        View = 433,
    }

    public enum Export
    {
        Allow = 434,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundraising.RENXT.Opportunities
{
    public enum Opportunitiestabs
    {
        Workopportunities = 438,

        Listsopportunities = 439,

        Analyzeopportunities = 440,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundraising.RENXT.Work
{
    public enum Portfolio
    {
        View = 450,
    }

    public enum Gifts
    {
        View = 451,
    }

    public enum Actions
    {
        View = 452,
    }

    public enum Unassigned
    {
        View = 453,
    }

    public enum Changefundraiser
    {
        Allow = 454,
    }

    public enum Export
    {
        Allow = 455,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.RENXT.Datahealth
{
    public enum Duplicatemanagement
    {
        View = 462,

        Manage = 463,
    }

    public enum Datahealthservices
    {
        View = 460,

        Manage = 461,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundraising.RENXT.Auctions
{
    public enum Auctions
    {
        Access = 443,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.RENXT.Workflowdesigner
{
    public enum Workflows
    {
        View = 468,

        AddEdit = 469,

        Delete = 470,
    }

    public enum Actionworkflows
    {
        Apply = 471,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.AUC.Security
{
    public enum Users
    {
        View = 479,

        AddEdit = 480,

        MarkInactive = 481,
    }

    public enum Roles
    {
        View = 482,

        AddEdit = 483,

        MarkInactive = 484,

        Delete = 485,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Events.AUC.Auctions
{
    public enum Auctions
    {
        Manage = 487,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundmanagement.Spendingpolicies
{
    public enum Spendingpolicies
    {
        View = 494,

        Add = 495,

        Edit = 496,

        Delete = 497,

        Calculate = 498,

        Adjustamounts = 499,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundmanagement.FENXT.Spendingpolicies
{
    public enum Spendingpolicies
    {
        View = 506,

        Add = 507,

        Edit = 508,

        Delete = 509,

        Calculate = 510,

        Adjustamounts = 511,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.RENXT.Donationforms
{
    public enum Donationforms
    {
        View = 546,

        Delete = 548,

        AddEdit = 547,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Payments.MERCH.SKYAPI
{
    public enum Endpointaccess
    {
        All = 550,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.MERCH.Security
{
    public enum Users
    {
        View = 558,

        AddEdit = 559,

        MarkInactive = 560,
    }

    public enum Roles
    {
        View = 561,

        AddEdit = 562,

        MarkInactive = 563,

        Delete = 564,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Finderlists.Finderlists
{
    public enum Finderlists
    {
        View = 576,

        AddEdit = 577,

        Delete = 578,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Grantmaking.GRANTMAKING.Grantpayments
{
    public enum Grantpayments
    {
        View = 569,

        AddEdit = 570,

        Changestatus = 571,

        Delete = 572,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.FFS.Security
{
    public enum Users
    {
        View = 592,

        AddEdit = 593,

        MarkInactive = 594,
    }

    public enum Roles
    {
        View = 595,

        AddEdit = 596,

        MarkInactive = 597,

        Delete = 598,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Finderlists.FFS.Finderlists
{
    public enum Finderlists
    {
        View = 582,

        AddEdit = 583,

        Delete = 584,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.SUPTL.Security
{
    public enum Users
    {
        View = 606,

        AddEdit = 607,

        MarkInactive = 608,
    }

    public enum Roles
    {
        View = 609,

        AddEdit = 610,

        MarkInactive = 611,

        Delete = 612,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.SUPTL.Donationforms
{
    public enum Donationforms
    {
        View = 619,
    }

    public enum Servicebus
    {
        Republishone = 621,

        Republishmany = 622,

        Viewdeadletterqueuemessages = 623,

        Deletedeadletterqueuemessages = 624,
    }

    public enum Transactions
    {
        View = 620,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Constituents.SUPTL.Smallgroups
{
    public enum Smallgroups
    {
        View = 627,

        Manage = 628,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Finderlists.SUPTL.Supportal
{
    public enum Supportal
    {
        View = 636,

        AddEdit = 637,

        Delete = 638,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.DONOTUSE.Security
{
    public enum Users
    {
        View = 646,

        AddEdit = 647,

        MarkInactive = 648,
    }

    public enum Roles
    {
        View = 649,

        AddEdit = 650,

        MarkInactive = 651,

        Delete = 652,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Offers.SUPTL.Offersupport
{
    public enum Offersupport
    {
        View = 631,

        Manage = 632,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.DC.Security
{
    public enum Users
    {
        View = 660,

        AddEdit = 661,

        MarkInactive = 662,
    }

    public enum Roles
    {
        View = 663,

        AddEdit = 664,

        MarkInactive = 665,

        Delete = 666,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.IOM.SUPTL.IOM
{
    public enum CompanyCRM
    {
        View = 670,

        Operate = 671,

        Manage = 672,

        Support = 2573,
    }

    public enum ResearchPoint
    {
        View = 712,

        Operate = 713,

        Manage = 714,

        Support = 2574,
    }

    public enum NetCommunity
    {
        View = 2755,

        Operate = 2756,

        Manage = 2757,

        Support = 2758,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Benchmarking.Benchmarking
{
    public enum Directmarketingindex
    {
        View = 1282,
    }

    public enum Highereducationdashboards
    {
        View = 674,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Performance.Performance
{
    public enum Dashboards
    {
        View = 678,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundraising.RENXT.Receiptmanagement
{
    public enum Receipts
    {
        View = 1202,

        Generate = 683,

        Managereceipttemplates = 1203,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundraising.Receiptmanagement
{
    public enum Receipts
    {
        View = 1118,

        Generate = 681,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Constituents.Smallgroups
{
    public enum Smallgroups
    {
        View = 688,

        AddEdit = 689,

        Delete = 690,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Marketing.Communicationpreferences
{
    public enum Communicationpreferences
    {
        View = 691,

        Add = 692,

        Delete = 693,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Marketing.RENXT.Communicationpreferences
{
    public enum Communicationpreferences
    {
        View = 697,

        Add = 698,

        Delete = 699,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.RENXT.Posttogeneralledger
{
    public enum Gifts
    {
        View = 703,

        Validate = 704,

        Post = 705,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.Posttogeneralledger
{
    public enum Gifts
    {
        View = 700,

        Validate = 701,

        Post = 702,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Marketing.LO.Communicationpreferences
{
    public enum Communicationpreferences
    {
        View = 709,

        Add = 710,

        Delete = 711,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Grantmaking.GRANTMAKING.Application
{
    public enum Applications
    {
        Consider = 715,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Constituents.RENXT.Smallgroups
{
    public enum Smallgroups
    {
        View = 706,

        AddEdit = 707,

        Delete = 708,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Grantmaking.GRANTMAKING.Grant
{
    public enum Grants
    {
        View = 718,

        Edit = 719,

        Approve = 720,

        Decline = 721,

        Reverttopending = 722,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Grantmaking.GRANTMAKING.Organization
{
    public enum Organizations
    {
        View = 723,

        AddEdit = 724,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Grantmaking.GRANTMAKING.Contact
{
    public enum Contacts
    {
        View = 716,

        AddEdit = 717,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Churchmanagementsupportal.SUPTL.MobileMission
{
    public enum MobileMissionSupportal
    {
        View = 725,

        Manage = 726,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.Fieldsandtables
{
    public enum Systemfields
    {
        View = 727,

        Edit = 728,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.TMS.SUPTL.Billingmanagement
{
    public enum Transactions
    {
        View = 732,

        AddEdit = 752,

        Delete = 753,
    }

    public enum Notifications
    {
        View = 731,

        AddEdit = 750,

        Delete = 751,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundmanagement.Funds
{
    public enum Funds
    {
        View = 733,

        AddEdit = 734,

        Delete = 735,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.RENXT.Fieldsandtables
{
    public enum Tableentries
    {
        Edit = 1424,
    }

    public enum Systemfields
    {
        View = 729,

        Edit = 730,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundraising.RENXT.Fund
{
    public enum Funds
    {
        View = 736,

        AddEdit = 737,
    }

    public enum Accounts
    {
        View = 738,

        AddEdit = 739,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.EDU.Security
{
    public enum Roles
    {
        View = 746,

        AddEdit = 747,

        MarkInactive = 748,

        Delete = 749,
    }

    public enum Users
    {
        View = 743,

        AddEdit = 744,

        MarkInactive = 745,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountmanagement.Accounts
{
    public enum Accounts
    {
        View = 740,

        AddEdit = 741,

        Delete = 742,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.CompanyUniversity.SUPTL.CompanyUniversity
{
    public enum Classroom
    {
        View = 754,

        AddEdit = 755,

        Delete = 756,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.RENXT.Constituentrecordssettings
{
    public enum Deceasedrecordssettings
    {
        View = 757,

        Edit = 758,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.Constituentrecordssettings
{
    public enum Deceasedrecordssettings
    {
        View = 759,

        Edit = 760,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Constituents.Constituents
{
    public enum Constituent
    {
        View = 761,

        AddEdit = 762,
    }

    public enum Alerts
    {
        View = 763,

        AddEdit = 764,
    }

    public enum Notes
    {
        View = 765,

        AddEdit = 766,

        Delete = 767,
    }

    public enum Individualrelationships
    {
        View = 768,

        AddEdit = 769,

        Delete = 770,
    }

    public enum Organizationrelationships
    {
        View = 771,

        AddEdit = 772,

        Delete = 773,
    }

    public enum ConstituentID
    {
        AddEdit = 774,
    }

    public enum Personalinformation
    {
        AddEdit = 775,
    }

    public enum Nameformats
    {
        AddEdit = 776,
    }

    public enum Aliases
    {
        View = 777,

        AddEdit = 778,
    }

    public enum Userlink
    {
        AddEdit = 779,
    }

    public enum Customfields
    {
        View = 780,

        AddEdit = 781,

        Delete = 782,
    }

    public enum Attachments
    {
        View = 783,

        AddEdit = 784,

        Delete = 785,
    }

    public enum Assignedfundraiser
    {
        View = 786,

        AddEdit = 787,
    }

    public enum Fundraiserdetails
    {
        View = 788,

        AddEdit = 789,
    }

    public enum Addresses
    {
        View = 790,

        Add = 791,

        Edit = 792,

        Delete = 793,
    }

    public enum Emailaddresses
    {
        View = 794,

        Add = 795,

        Edit = 796,

        Delete = 797,
    }

    public enum Onlinepresence
    {
        View = 798,

        Add = 799,

        Edit = 800,

        Delete = 801,
    }

    public enum Phonenumbers
    {
        View = 802,

        Add = 803,

        Edit = 804,

        Delete = 805,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Delivery.SUPTL.Legacydatabasestamping
{
    public enum Stampingscripts
    {
        View = 851,
    }

    public enum Queues
    {
        View = 852,

        AddEdit = 853,

        Delete = 854,
    }

    public enum Settings
    {
        View = 855,

        AddEdit = 856,

        Delete = 857,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Constituents.RENXT.Constituents
{
    public enum Constituents
    {
        View = 806,

        AddEdit = 807,
    }

    public enum Alerts
    {
        View = 808,

        AddEdit = 809,
    }

    public enum Notes
    {
        View = 810,

        AddEdit = 811,

        Delete = 812,
    }

    public enum Individualrelationships
    {
        View = 813,

        AddEdit = 814,

        Delete = 815,
    }

    public enum Organizationrelationships
    {
        View = 816,

        AddEdit = 817,

        Delete = 818,
    }

    public enum ConstituentID
    {
        AddEdit = 819,
    }

    public enum Personalinformation
    {
        AddEdit = 820,
    }

    public enum Nameformats
    {
        AddEdit = 821,
    }

    public enum Aliases
    {
        View = 822,

        AddEdit = 823,
    }

    public enum Userlink
    {
        AddEdit = 824,
    }

    public enum Customfields
    {
        View = 825,

        AddEdit = 826,

        Delete = 827,
    }

    public enum Attachments
    {
        View = 828,

        AddEdit = 829,

        Delete = 830,
    }

    public enum Assignedfundraiser
    {
        View = 831,

        AddEdit = 832,
    }

    public enum Fundraiserdetails
    {
        View = 833,

        AddEdit = 834,
    }

    public enum Addresses
    {
        View = 835,

        Add = 836,

        Edit = 837,

        Delete = 838,
    }

    public enum Emailaddresses
    {
        View = 839,

        Add = 840,

        Edit = 841,

        Delete = 842,
    }

    public enum Onlinepresence
    {
        View = 843,

        Add = 844,

        Edit = 845,

        Delete = 846,
    }

    public enum Phonenumbers
    {
        View = 847,

        Add = 848,

        Edit = 849,

        Delete = 850,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Volunteermanagementsupportal.SUPTL.Volunteermanagementsupportal
{
    public enum Volunteers
    {
        View = 858,

        Manage = 859,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.AONsupportal.SUPTL.Supportal
{
    public enum Supportal
    {
        View = 860,

        AddEdit = 861,

        Delete = 862,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.FNDLT.Connectedservicessettings
{
    public enum Connectedservices
    {
        View = 885,

        Manage = 886,
    }

    public enum Confirmationemails
    {
        View = 883,

        Manage = 884,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.FNDLT.Security
{
    public enum Users
    {
        View = 873,

        AddEdit = 874,

        MarkInactive = 875,
    }

    public enum Roles
    {
        View = 876,

        AddEdit = 877,

        MarkInactive = 878,

        Delete = 879,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Constituents.FNDLT.Constituents
{
    public enum Constituents
    {
        View = 880,

        AddEdit = 881,

        Delete = 882,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Gifts.FNDLT.Gifts
{
    public enum Gifts
    {
        View = 887,

        AddEdit = 888,

        Delete = 889,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Analysis.Education
{
    public enum Insights
    {
        AddEdit = 890,

        Delete = 891,
    }

    public enum Dashboards
    {
        View = 892,

        AddEdit = 893,

        Delete = 894,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Analysis.EDU.Education
{
    public enum Insights
    {
        AddEdit = 895,

        Delete = 896,
    }

    public enum Dashboards
    {
        View = 897,

        AddEdit = 898,

        Delete = 899,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Educationsupportal.SUPTL.Schools
{
    public enum Schools
    {
        View = 900,

        AddEdit = 901,

        Deprecate = 902,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Educationsupportal.SUPTL.Employeeaccounts
{
    public enum Accounts
    {
        View = 903,

        AddEdit = 904,

        Delete = 905,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Educationsupportal.SUPTL.Environmentmappings
{
    public enum Environmentmappings
    {
        View = 906,

        AddEdit = 907,

        Delete = 908,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Educationsupportal.SUPTL.Deprecatedschools
{
    public enum Deprecatedschools
    {
        View = 909,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Marketing.SMS
{
    public enum SMS
    {
        Manage = 912,

        View = 913,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Educationsupportal.SUPTL.Settings
{
    public enum Settings
    {
        View = 910,

        Edit = 911,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Marketing.RENXT.SMS
{
    public enum SMS
    {
        Manage = 914,

        View = 915,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Receiptingsupportal.SUPTL.Receipting
{
    public enum Receipting
    {
        View = 919,

        Operate = 920,

        Restricted = 921,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.RUAsupportal.SUPTL.Requireduseractions
{
    public enum Requireduseractions
    {
        View = 916,

        Operate = 917,

        Restricted = 918,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Giftdatatransformsupportal.SUPTL.Guidedfundraising
{
    public enum Guidedfundraising
    {
        View = 925,

        Operate = 926,

        Restricted = 927,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Giftdatatransformsupportal.SUPTL.Giftdatatransform
{
    public enum Giftdatatransform
    {
        View = 922,

        Operate = 923,

        Restricted = 924,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.SUPTL.Workflowdesigner
{
    public enum Workflows
    {
        View = 928,

        Modify = 929,
    }

    public enum Servicebuses
    {
        View = 930,

        Modify = 931,
    }

    public enum Databaseconfigurations
    {
        View = 932,

        Modify = 933,
    }

    public enum Loadtests
    {
        Run = 934,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.RENXT.Communicationformdesigner
{
    public enum Communicationformdesigner
    {
        View = 938,

        AddEdit = 939,

        Delete = 940,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.FAITH.Security
{
    public enum Users
    {
        View = 941,

        AddEdit = 942,

        MarkInactive = 943,
    }

    public enum Roles
    {
        View = 944,

        AddEdit = 945,

        MarkInactive = 946,

        Delete = 947,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.GRMKG.Security
{
    public enum Users
    {
        View = 948,

        AddEdit = 949,

        MarkInactive = 950,
    }

    public enum Roles
    {
        View = 951,

        AddEdit = 952,

        MarkInactive = 953,

        Delete = 954,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Grantmaking.Workspace
{
    public enum Workspace
    {
        View = 955,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.Communicationformdesigner
{
    public enum Communicationformdesigner
    {
        View = 935,

        AddEdit = 936,

        Delete = 937,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.Donationforms
{
    public enum Donationforms
    {
        View = 960,

        AddEdit = 961,

        Delete = 962,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Scheduledpayments.SUPTL.Scheduledpayments
{
    public enum Supportal
    {
        View = 957,

        Operate = 958,

        Restricted = 959,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.FAITH.Donationforms
{
    public enum Donationforms
    {
        View = 963,

        AddEdit = 964,

        Delete = 965,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Grantmaking.GRMKG.Workspace
{
    public enum Workspaces
    {
        Access = 956,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Marketing.SUPTL.Social
{
    public enum Supportal
    {
        View = 969,

        Operate = 970,

        Restricted = 971,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Educationsupportal.SUPTL.Installs
{
    public enum Installs
    {
        View = 966,

        AddEdit = 967,

        Delete = 968,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Revenue.Designation
{
    public enum Designation
    {
        View = 972,

        AddEdit = 973,

        Delete = 974,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.People.People
{
    public enum Taxinfo
    {
        View = 2624,

        AddEdit = 2625,
    }

    public enum Confidential
    {
        Access = 978,
    }

    public enum People
    {
        View = 975,

        AddEdit = 976,

        Delete = 977,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.People.FAITH.People
{
    public enum Confidential
    {
        Access = 982,
    }

    public enum People
    {
        View = 979,

        AddEdit = 980,

        Delete = 981,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.TCSPM.Security
{
    public enum Users
    {
        View = 983,

        AddEdit = 984,

        MarkInactive = 985,
    }

    public enum Roles
    {
        View = 986,

        AddEdit = 987,

        MarkInactive = 988,

        Delete = 989,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Legalentitysupportal.SUPTL.Legalentitymanagement
{
    public enum Packages
    {
        Add = 996,

        Edit = 997,

        Delete = 998,

        Managepackages = 2620,
    }

    public enum Environmentadministrator
    {
        Add = 994,

        Delete = 995,
    }

    public enum Legalentityadministrator
    {
        Add = 992,

        Delete = 993,
    }

    public enum Environment
    {
        Markactive = 1020,

        Markinactive = 1021,

        Add = 990,

        Edit = 991,

        Delete = 1306,
    }

    public enum User
    {
        Export = 2661,

        Delete = 1010,
    }

    public enum Capability
    {
        Restorecommerceevent = 1037,

        Provisionforactivations = 1077,

        Purge = 2888,
    }

    public enum Project
    {
        Add = 1207,

        Edit = 1208,

        Delete = 1209,
    }

    public enum Legalentity
    {
        Merge = 1399,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.TCSPM.Donationforms
{
    public enum Donationforms
    {
        View = 1011,

        AddEdit = 1012,

        Delete = 1013,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.People.TCSPM.People
{
    public enum People
    {
        View = 999,

        AddEdit = 1000,

        Delete = 1001,
    }

    public enum Confidential
    {
        Access = 1002,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Revenue.FNDLT.Donationforms
{
    public enum Donationforms
    {
        View = 1014,

        AddEdit = 1015,

        Delete = 1016,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Revenue.FAITH.Designation
{
    public enum Designation
    {
        View = 1003,

        AddEdit = 1004,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Revenue.FNDLT.Designation
{
    public enum Designation
    {
        View = 1017,

        AddEdit = 1018,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.SUPTL.Communicationformdesigner
{
    public enum Supportal
    {
        View = 1025,

        Operate = 1026,

        Restricted = 1027,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Financial.SUPTL.Journalsupportal
{
    public enum Deadletterqueue
    {
        Manage = 2601,
    }

    public enum Durableorchestrations
    {
        Manage = 2602,
    }

    public enum Cosmos
    {
        Manage = 2603,
    }

    public enum Supportal
    {
        View = 1007,

        Operate = 1008,

        Restricted = 1009,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Performancesupportal.SUPTL.Performance
{
    public enum Supportal
    {
        View = 1022,

        Operate = 1023,

        Restricted = 1024,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.SUPTL.Organizationsettings
{
    public enum Supportal
    {
        View = 1031,

        Operate = 1032,

        Restricted = 1033,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Giftbackoffice.SUPTL.Giftbackoffice
{
    public enum Supportal
    {
        View = 1028,

        Operate = 1029,

        Restricted = 1030,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Educationsupportal.SUPTL.Reports
{
    public enum Reports
    {
        Execute = 1048,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Reporting.SUPTL.Reporting
{
    public enum Supportal
    {
        View = 1034,

        Operate = 1035,

        Restricted = 1036,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Education.EDU.Analyze
{
    public enum Academicsdashboards
    {
        Performance = 1038,

        Performancebydepartment = 1039,
    }

    public enum Enrollmentmanagementdashboards
    {
        Admissionsoverview = 1041,

        Candidates = 1042,

        Capacityplanning = 1043,

        Contracts = 1044,
    }

    public enum Coredashboards
    {
        Studentenrollment = 1045,

        Logins = 1046,

        Communications = 1047,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.RENXTtenants.SUPTL.RENXTtenants
{
    public enum Tenants
    {
        View = 1049,
    }

    public enum Users
    {
        View = 1050,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Permissionssupportal.SUPTL.Executionplans
{
    public enum Executionplans
    {
        View = 1051,

        Manage = 1052,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.FNDLT.Generalsettings
{
    public enum Generalsettings
    {
        Manage = 1055,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.Generalsettings
{
    public enum Generalsettings
    {
        Manage = 1053,
    }

    public enum Merchantaccount
    {
        Add = 2810,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.FAITH.Generalsettings
{
    public enum Generalsettings
    {
        Manage = 1056,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Orgfocusareas.SUPTL.Orgfocusareas
{
    public enum Supportal
    {
        View = 1057,

        Operate = 1058,

        Restricted = 1059,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.TCSPM.Generalsettings
{
    public enum Generalsettings
    {
        Manage = 1054,
    }

    public enum Merchantaccounts
    {
        Add = 2835,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Dataingestion.SUPTL.Fileupload
{
    public enum Fileupload
    {
        View = 1060,

        Operate = 1061,

        Restricted = 1062,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.People.TCSPM.Actions
{
    public enum Actions
    {
        View = 1078,

        AddEdit = 1079,

        Delete = 1080,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Personassupportal.SUPTL.Personas
{
    public enum Personas
    {
        View = 1063,

        Manage = 1064,

        Delete = 1083,
    }

    public enum Features
    {
        View = 1065,

        Manage = 1066,

        Delete = 1084,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.People.Communicationpreferences
{
    public enum Communicationpreferences
    {
        View = 1086,

        AddEdit = 1087,
    }

    public enum Communicationpreferencesconfiguration
    {
        View = 1088,

        AddEdit = 1089,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.People.Actions
{
    public enum Actions
    {
        View = 1074,

        AddEdit = 1075,

        Delete = 1076,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.GN7FE.Security
{
    public enum Users
    {
        View = 1101,

        AddEdit = 1102,

        MarkInactive = 1103,
    }

    public enum Roles
    {
        View = 1104,

        AddEdit = 1105,

        MarkInactive = 1106,

        Delete = 1107,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.People.TCSPM.Communicationpreferences
{
    public enum Communicationpreferencesconfiguration
    {
        View = 1092,

        AddEdit = 1093,
    }

    public enum Communicationpreferences
    {
        View = 1090,

        AddEdit = 1091,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Import.Import
{
    public enum Peopleimport
    {
        Manage = 1081,
    }

    public enum Transactionimport
    {
        Manage = 1082,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.GN7EE.Security
{
    public enum Users
    {
        View = 1108,

        AddEdit = 1109,

        MarkInactive = 1110,
    }

    public enum Roles
    {
        View = 1111,

        AddEdit = 1112,

        MarkInactive = 1113,

        Delete = 1114,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.GN7RE.Security
{
    public enum Users
    {
        View = 1094,

        AddEdit = 1095,

        MarkInactive = 1096,
    }

    public enum Roles
    {
        View = 1097,

        AddEdit = 1098,

        MarkInactive = 1099,

        Delete = 1100,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Contributions.TCSPM.Contributions
{
    public enum Transactioninformation
    {
        View = 1133,

        AddEdit = 1134,

        Delete = 1135,
    }

    public enum Contributions
    {
        AddEdit = 1131,

        Delete = 1132,

        View = 1130,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.DonorCentrics.SUPTL.DonorCentrics
{
    public enum Supportal
    {
        View = 1115,

        Operate = 1116,

        Restricted = 1117,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Revenue.TCSPM.Receiptmanagement
{
    public enum Receipts
    {
        View = 1119,

        Manage = 1120,

        Editreceipttemplates = 1201,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Contributions.Contributions
{
    public enum Contributions
    {
        View = 1124,

        AddEdit = 1125,

        Delete = 1126,
    }

    public enum Transactioninformation
    {
        View = 1127,

        AddEdit = 1128,

        Delete = 1129,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Lists.SUPTL.Lists
{
    public enum Supportal
    {
        View = 1121,

        Operate = 1122,

        Restricted = 1123,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Contributions.Pledgereminders
{
    public enum Pledgereminders
    {
        View = 1148,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.CongregantPortalMobileMission
{
    public enum Congregantprofileupdatelog
    {
        Manage = 1142,
    }

    public enum Congregantuseraccess
    {
        Manage = 1140,
    }

    public enum CongregantPortalconfiguration
    {
        Manage = 1138,
    }

    public enum MobileMissionconfiguration
    {
        Manage = 1139,
    }

    public enum Congregantuseraccountactivitylog
    {
        Manage = 1141,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Revenue.TCSPM.Designations
{
    public enum Designations
    {
        View = 1136,

        AddEdit = 1137,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.RENXT.CongregantPortalMobileMission
{
    public enum Congregantuseraccess
    {
        Manage = 1145,
    }

    public enum Congregantuseraccountactivitylog
    {
        Manage = 1146,
    }

    public enum Congregantprofileupdatelog
    {
        Manage = 1147,
    }

    public enum CongregantPortalconfiguration
    {
        Manage = 1143,
    }

    public enum MobileMissionconfiguration
    {
        Manage = 1144,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Headquarters.Locations
{
    public enum Locations
    {
        View = 1163,

        Manage = 1164,
    }

    public enum Tables
    {
        View = 1165,

        Manage = 1166,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Contributions.TCSPM.Pledgereminders
{
    public enum Pledgereminders
    {
        View = 1149,

        Manage = 1150,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.TCSPM.Branding
{
    public enum Branding
    {
        Manage = 1175,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.ENM.Security
{
    public enum Users
    {
        View = 1151,

        AddEdit = 1152,

        MarkInactive = 1153,
    }

    public enum Roles
    {
        View = 1154,

        AddEdit = 1155,

        MarkInactive = 1156,

        Delete = 1157,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fimshostnetsupportal.SUPTL.Fimshostnetmanagement
{
    public enum Fimshostnetsupportal
    {
        Manage = 1158,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.TCSEvents.Eventmanagement
{
    public enum Participants
    {
        View = 1214,

        AddEdit = 1215,
    }

    public enum Events
    {
        View = 1167,

        AddEdit = 1168,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Headquarters.ENM.Locations
{
    public enum Locations
    {
        View = 1159,

        Manage = 1160,
    }

    public enum Tables
    {
        View = 1161,

        Manage = 1162,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.Branding
{
    public enum Branding
    {
        Manage = 1174,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Automatednotices.SUPTL.Automatednotices
{
    public enum Supportal
    {
        View = 1169,

        Operate = 1170,

        Restricted = 1171,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Emailmanager.SUPTL.Emailmanager
{
    public enum Supportal
    {
        View = 1176,

        Operate = 1177,

        Restricted = 1178,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Events.TCSPM.Eventmanagement
{
    public enum Participants
    {
        View = 1212,

        AddEdit = 1213,
    }

    public enum Events
    {
        View = 1172,

        AddEdit = 1173,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.TCSPM.Portal
{
    public enum Portalconfiguration
    {
        Manage = 1179,
    }

    public enum Portaluseraccess
    {
        Manage = 1180,
    }

    public enum Useraccountactivitylog
    {
        Manage = 1181,
    }

    public enum Profileupdatelog
    {
        Manage = 1182,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Prayerrequests.Prayerrequests
{
    public enum Prayerrequests
    {
        View = 1183,

        Manage = 1184,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Congregants.Membership
{
    public enum Membership
    {
        View = 1192,

        Manage = 1193,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Classes.Classes
{
    public enum Classes
    {
        View = 1185,

        Manage = 1186,
    }

    public enum Operatecheckin
    {
        Enable = 1187,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Facilities.Facilities
{
    public enum Facilities
    {
        View = 1188,

        Manage = 1189,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.BBMS.Security
{
    public enum Users
    {
        View = 1194,

        AddEdit = 1195,

        MarkInactive = 1196,
    }

    public enum Roles
    {
        View = 1197,

        AddEdit = 1198,

        MarkInactive = 1199,

        Delete = 1200,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.TCSFieldsandtables
{
    public enum Fieldsandtables
    {
        View = 2848,

        Manage = 1204,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Engagement.Engagement
{
    public enum Engagement
    {
        View = 1206,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Congregants.Faithjourney
{
    public enum Faithjourney
    {
        View = 1190,

        Manage = 1191,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.TCSPM.Fieldsandtables
{
    public enum Fieldsandtables
    {
        Manage = 1205,

        View = 2856,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Luminate.SUPTL.Luminate
{
    public enum Servicebus
    {
        Republishone = 1266,

        Republishmany = 1267,

        Viewdeadletterqueuemessages = 1268,

        Deletedeadletterqueuemessages = 1269,
    }

    public enum Luminatesupportal
    {
        View = 1218,

        Configureluminate = 1219,

        Getdbsummaries = 1220,

        Delete = 1221,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Merchantaccounts.Paymentconfiguration
{
    public enum Paymentconfiguration
    {
        Manage = 1216,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Merchantaccounts.TCSPM.Paymentconfiguration
{
    public enum Paymentconfiguration
    {
        Manage = 1217,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Merchantservices.Settings
{
    public enum Accountconfigurations
    {
        View = 1224,

        AddEdit = 1225,

        Delete = 1226,
    }

    public enum Contactdetails
    {
        View = 1222,

        AddEdit = 1223,
    }

    public enum Disbursementinformation
    {
        View = 1231,

        AddEdit = 1232,
    }

    public enum Emailacknowledgements
    {
        View = 1227,

        AddEdit = 1228,
    }

    public enum Emailnotifications
    {
        View = 1229,

        AddEdit = 1230,
    }

    public enum Admin
    {
        Allow = 1491,
    }

    public enum PayPalconfiguration
    {
        Manage = 2946,
    }

    public enum Accountinformation
    {
        Manage = 2947,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Merchantservices.BBMS.Settings
{
    public enum Contactdetails
    {
        View = 1248,

        AddEdit = 1249,
    }

    public enum Accountconfigurations
    {
        View = 1250,

        AddEdit = 1251,

        Delete = 1252,
    }

    public enum Emailacknowledgements
    {
        View = 1253,

        AddEdit = 1254,
    }

    public enum Emailnotifications
    {
        View = 1255,

        AddEdit = 1256,
    }

    public enum Disbursementinformation
    {
        View = 1257,

        AddEdit = 1258,
    }

    public enum PayPalconfiguration
    {
        Manage = 2956,
    }

    public enum Accountinformation
    {
        Manage = 2957,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Merchantservices.Transactionmanagement
{
    public enum Suspecttransactions
    {
        View = 2635,

        Accept = 2636,
    }

    public enum Refundtransactions
    {
        Allow = 1238,
    }

    public enum Addtransactions
    {
        Allow = 1239,
    }

    public enum Disputes
    {
        View = 1233,

        Accept = 1234,

        Challenge = 1235,
    }

    public enum Deidentifytransactions
    {
        Allow = 2949,
    }

    public enum Transactionlists
    {
        Allow = 1236,

        Export = 1237,

        Manage = 2948,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Merchantservices.BBMS.Transactionmanagement
{
    public enum Suspecttransactions
    {
        View = 2633,

        Accept = 2634,
    }

    public enum Refundtransactions
    {
        Allow = 1246,
    }

    public enum Addtransactions
    {
        Allow = 1247,
    }

    public enum Disputes
    {
        View = 1241,

        Accept = 1242,

        Challenge = 1243,
    }

    public enum Transactionlists
    {
        Allow = 1244,

        Export = 1245,

        Manage = 2954,
    }

    public enum Deidentifytransactions
    {
        Allow = 2955,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Merchantservices.Reporting
{
    public enum Disbursementreports
    {
        View = 1240,
    }

    public enum Transactiontotalsreport
    {
        View = 2632,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.SUPTL.Actions
{
    public enum Supportal
    {
        View = 1260,

        Operate = 1261,

        Restricted = 1262,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.FIMS.Security
{
    public enum Users
    {
        View = 1270,

        AddEdit = 1271,

        MarkInactive = 1272,
    }

    public enum Roles
    {
        View = 1273,

        AddEdit = 1274,

        MarkInactive = 1275,

        Delete = 1276,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.SUPTL.Codetables
{
    public enum Supportal
    {
        View = 1263,

        Operate = 1264,

        Restricted = 1265,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Applicationsecurity.HostNetsecurity
{
    public enum HostNetapplications
    {
        Access = 1279,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Contributions.TCSPM.Tributes
{
    public enum Tributes
    {
        Manage = 1278,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Contributions.Tributes
{
    public enum Tributes
    {
        Manage = 1277,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Merchantservices.BBMS.Reporting
{
    public enum Transactiontotalsreport
    {
        View = 2631,
    }

    public enum Disbursementreports
    {
        View = 1259,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Applicationsecurity.FIMS.HostNetsecurity
{
    public enum HostNetapplicationss
    {
        Access = 1280,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Treasury.TCSPM.Deposits
{
    public enum Workflow
    {
        Movecontributions = 1292,

        Approve = 1293,

        Reopen = 1294,
    }

    public enum Deposits
    {
        View = 1289,

        AddEdit = 1290,

        Delete = 1291,

        Void = 2966,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Donut.SUPTL.Donut
{
    public enum Supportal
    {
        View = 1295,

        Operate = 1296,

        Restricted = 1297,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Treasury.Deposits
{
    public enum Deposits
    {
        View = 1283,

        AddEdit = 1284,

        Delete = 1285,

        Void = 2963,
    }

    public enum Workflow
    {
        Movecontributions = 1286,

        Approve = 1287,

        Reopen = 1288,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Lists.Lists
{
    public enum Lists
    {
        Manage = 1304,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Lists.TCSPM.Lists
{
    public enum Lists
    {
        Manage = 1305,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.CustOpsprojectmanagement.SUPTL.Supportal
{
    public enum Projects
    {
        View = 1298,

        AddEdit = 1299,

        Delete = 1300,
    }

    public enum Projecttemplates
    {
        View = 1301,

        AddEdit = 1302,

        Delete = 1303,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundraising.SUPTL.Prospectintelligence
{
    public enum Prospectintelligence
    {
        View = 1309,

        Operate = 1310,

        Restricted = 1311,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Receivables.Record
{
    public enum Payments
    {
        View = 1393,

        Add = 1394,

        Delete = 1395,

        Edit = 2706,

        Viewdistributions = 2787,

        Managedistributions = 2788,
    }

    public enum Charges
    {
        View = 1315,

        Add = 1316,

        Delete = 1317,

        Edit = 2707,

        Viewdistributions = 2789,

        Managedistributions = 2790,
    }

    public enum Invoices
    {
        View = 1324,

        Add = 1325,

        Delete = 1326,

        Edit = 2708,
    }

    public enum Credits
    {
        View = 1321,

        Add = 1322,

        Delete = 1323,

        Edit = 2709,

        Viewdistributions = 2791,

        Managedistributions = 2792,
    }

    public enum Salestax
    {
        View = 1330,

        Add = 1331,

        Delete = 1332,

        Edit = 2710,
    }

    public enum Ledgeraccess
    {
        View = 1327,

        Add = 1328,

        Delete = 1329,

        Edit = 2711,
    }

    public enum Clients
    {
        View = 1318,

        Add = 1319,

        Delete = 1320,

        Edit = 2712,

        Viewdistributions = 2793,

        Managedistributions = 2794,
    }

    public enum Billingitems
    {
        View = 1312,

        Add = 1313,

        Delete = 1314,

        Edit = 2713,

        Viewdistributions = 2795,

        Managedistributions = 2796,
    }

    public enum Statements
    {
        View = 2716,

        Add = 2717,

        Delete = 2718,

        Edit = 2719,
    }

    public enum Recurringinvoiceplans
    {
        Add = 2720,

        Edit = 2722,

        Delete = 2723,

        View = 2721,
    }

    public enum Statementtemplates
    {
        View = 2724,

        Add = 2725,

        Edit = 2726,

        Delete = 2727,
    }

    public enum Invoicetemplates
    {
        View = 2728,

        Add = 2729,

        Edit = 2730,

        Delete = 2731,
    }

    public enum Customfields
    {
        View = 2747,

        Edit = 2749,

        Add = 2748,

        Delete = 2750,
    }

    public enum Attachments
    {
        View = 2751,

        Add = 2752,

        Edit = 2753,

        Delete = 2754,
    }

    public enum Deposits
    {
        View = 2849,

        Edit = 2850,

        Add = 2851,

        Delete = 2852,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.Customfields
{
    public enum Customfields
    {
        View = 1307,

        Manage = 1308,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Permissionsmigration.SUPTL.Permissionsmigration
{
    public enum Supportal
    {
        View = 1369,

        Operate = 1370,

        Restricted = 1371,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Educationmanagement.SUPTL.Studentinformationsystems
{
    public enum Supportal
    {
        View = 1354,

        Operate = 1355,

        Restricted = 1356,
    }

    public enum Selfregistration
    {
        View = 1357,

        Operate = 1358,

        Restricted = 1359,
    }

    public enum Academicqualifications
    {
        View = 1360,

        Operate = 1361,

        Restricted = 1362,
    }

    public enum Enrollmentstatus
    {
        View = 1363,

        Operate = 1364,

        Restricted = 1365,
    }

    public enum Classificationcalculation
    {
        View = 1366,

        Operate = 1367,

        Restricted = 1368,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Receivables.TCSPM.Record
{
    public enum Billingitems
    {
        View = 1333,

        Delete = 1335,

        AddEdit = 1334,

        Viewdistributions = 2822,

        Managedistributions = 2823,
    }

    public enum Charges
    {
        View = 1336,

        Delete = 1338,

        AddEdit = 1337,

        Viewdistributions = 2824,

        Managedistributions = 2825,
    }

    public enum Clients
    {
        Delete = 1341,

        View = 1339,

        AddEdit = 1340,
    }

    public enum Salestax
    {
        View = 1351,

        Delete = 1353,

        AddEdit = 1352,
    }

    public enum Credits
    {
        View = 1342,

        Delete = 1344,

        AddEdit = 1343,

        Viewdistributions = 2826,

        Managedistributions = 2827,
    }

    public enum Invoices
    {
        View = 1345,

        Delete = 1347,

        AddEdit = 1346,
    }

    public enum Ledgeraccess
    {
        View = 1348,

        Delete = 1350,

        AddEdit = 1349,
    }

    public enum Payments
    {
        Delete = 1398,

        View = 1396,

        AddEdit = 1397,
    }

    public enum Statements
    {
        View = 2732,

        AddEdit = 2733,

        Delete = 2734,
    }

    public enum Recurringinvoiceplans
    {
        View = 2735,

        AddEdit = 2736,

        Delete = 2737,
    }

    public enum Statementtemplates
    {
        View = 2738,

        AddEdit = 2739,

        Delete = 2740,
    }

    public enum Invoicetemplates
    {
        View = 2741,

        AddEdit = 2742,

        Delete = 2743,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.Attachment
{
    public enum Attachments
    {
        View = 1372,

        Add = 1373,

        Edit = 1374,

        Delete = 1375,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Designations.SUPTL.Designations
{
    public enum Supportal
    {
        View = 1384,

        Operate = 1385,

        Restricted = 1386,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Communications.Email
{
    public enum Recipients
    {
        View = 2584,
    }

    public enum Email
    {
        View = 1380,

        AddEdit = 1381,

        Send = 1382,
    }

    public enum Settings
    {
        AddEdit = 1383,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Compliance.SUPTL.Compliance
{
    public enum Eligibilityoverrides
    {
        Add = 1379,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Contributions.SUPTL.Contributions
{
    public enum Supportal
    {
        View = 1390,

        Operate = 1391,

        Restricted = 1392,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Schooldata.ENM.Schooldata
{
    public enum People
    {
        View = 1401,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Customerportal.SUPTL.Customerportal
{
    public enum Supportal
    {
        View = 1376,

        Operate = 1377,

        Restricted = 1378,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.SUPTL.Treasury
{
    public enum Supportal
    {
        View = 1387,

        Operate = 1388,

        Restricted = 1389,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Schooldata.Schooldata
{
    public enum People
    {
        View = 1400,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.GSRCH.Security
{
    public enum Users
    {
        View = 1403,

        AddEdit = 1404,

        MarkInactive = 1405,
    }

    public enum Roles
    {
        View = 1406,

        AddEdit = 1407,

        MarkInactive = 1408,

        Delete = 1409,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Lists.ENM.Lists
{
    public enum Lists
    {
        Manage = 1402,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundraising.Prospectworkflow
{
    public enum Prospects
    {
        View = 1416,

        Qualify = 1417,

        Assign = 1418,

        Suppress = 1419,

        Managepersonalportfolio = 1504,

        Manageallportfolios = 1505,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.GivingSearch.GSRCH.GivingSearch
{
    public enum Search
    {
        View = 1411,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Serviceprincipalmanagement.SUPTL.Serviceprincipal
{
    public enum Serviceprincipal
    {
        View = 1413,

        AddEdit = 1414,

        Delete = 1415,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundraising.RENXT.Tributemanagement
{
    public enum Tributemanagement
    {
        Manage = 1412,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.GivingSearch.GivingSearch
{
    public enum Search
    {
        View = 1410,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.RENXT.Portal
{
    public enum Configuration
    {
        Manage = 1425,
    }

    public enum Useraccess
    {
        Manage = 1426,
    }

    public enum Useraccountactivitylog
    {
        Manage = 1427,
    }

    public enum Profileupdatelog
    {
        Manage = 1428,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Treasury.Bankaccounts
{
    public enum Bankaccounts
    {
        View = 1420,

        Add = 1421,

        Edit = 1422,

        Delete = 1423,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Receivables.TCSPM.Configuration
{
    public enum Settings
    {
        Manage = 1452,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Backofficeintegrations.SUPTL.Backofficeintegrations
{
    public enum Accounttracing
    {
        View = 1429,

        Operate = 1430,
    }

    public enum Accounthistory
    {
        View = 1431,

        Operate = 1432,
    }

    public enum Financialtracing
    {
        View = 1433,

        Operate = 1434,
    }

    public enum Financialhistory
    {
        View = 1435,

        Operate = 1436,
    }

    public enum Accountdeadletter
    {
        View = 1437,

        Retry = 1438,

        Delete = 1439,
    }

    public enum Financialdeadletter
    {
        View = 1440,

        Retry = 1441,

        Delete = 1442,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Treasury.Configuration
{
    public enum Settings
    {
        Manage = 1450,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Receivables.Configuration
{
    public enum Settings
    {
        Manage = 1451,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Treasury.TCSPM.Configuration
{
    public enum Settings
    {
        Manage = 1453,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.COP.Security
{
    public enum Users
    {
        View = 1466,

        AddEdit = 1467,

        MarkInactive = 1468,
    }

    public enum Roles
    {
        View = 1469,

        AddEdit = 1470,

        MarkInactive = 1471,

        Delete = 1472,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundraising.RENXT.Prospectworkflow
{
    public enum Prospects
    {
        View = 1443,

        Qualify = 1444,

        Assign = 1445,

        Suppress = 1446,

        Managepersonalportfolio = 1506,

        Manageallportfolios = 1507,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Treasury.Miscpayments
{
    public enum Miscpaymentcategories
    {
        View = 1460,

        AddEdit = 1461,

        Delete = 1462,

        Viewdistributions = 2828,

        Managedistributions = 2829,
    }

    public enum Miscpayments
    {
        View = 1454,

        AddEdit = 1455,

        Delete = 1456,

        Viewdistributions = 2830,

        Managedistributions = 2831,

        Void = 2964,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tributes.SUPTL.Tributes
{
    public enum Supportal
    {
        View = 1447,

        Operate = 1448,

        Restricted = 1449,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Treasury.TCSPM.Miscpayments
{
    public enum Miscpaymentcategories
    {
        View = 1463,

        AddEdit = 1464,

        Delete = 1465,
    }

    public enum Miscpayments
    {
        View = 1457,

        AddEdit = 1458,

        Delete = 1459,

        Void = 2967,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Merchantservices.BBMS.Paymentterminal
{
    public enum Devices
    {
        View = 1481,

        AddEdit = 1482,
    }

    public enum Orders
    {
        View = 1483,

        AddEdit = 1484,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Merchantservices.Paymentterminal
{
    public enum Devices
    {
        View = 1477,

        AddEdit = 1478,
    }

    public enum Orders
    {
        View = 1479,

        AddEdit = 1480,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Customersuccessmanagement.Customersuccessmanagement
{
    public enum Projects
    {
        View = 1473,

        Edit = 1474,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.MobilePayterminal.Transactions
{
    public enum Addtransaction
    {
        Allow = 1485,
    }

    public enum Refundtransaction
    {
        Allow = 1486,
    }

    public enum Viewtransaction
    {
        Allow = 1487,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fundraising.RENXT.JustGivingintegration
{
    public enum Peertopeerfundraising
    {
        View = 1498,
    }

    public enum Giftrecognitioncredits
    {
        View = 1499,

        Edit = 1500,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.MobilePayterminal.BBMS.Transactions
{
    public enum Addtransaction
    {
        Allow = 1488,
    }

    public enum Refundtransaction
    {
        Allow = 1489,
    }

    public enum Viewtransaction
    {
        Allow = 1490,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Files.SUPTL.Files
{
    public enum Supportal
    {
        View = 1494,

        Operate = 1495,

        Restricted = 1496,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Customersuccessmanagement.COP.Customersuccessmanagement
{
    public enum Projects
    {
        View = 1475,

        Edit = 1476,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Headquarterstools.Datahealth
{
    public enum GlobalID
    {
        Manage = 1493,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Headquarterstools.ENM.Datahealth
{
    public enum GlobalID
    {
        Manage = 1492,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.RENXT.JustGivingintegration
{
    public enum Settings
    {
        Manage = 1497,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.SUPTL.Customfield
{
    public enum Supportal
    {
        View = 1501,

        Operate = 1502,

        Restricted = 1503,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountspayable.FENXT.Administration
{
    public enum Mergevendors
    {
        Access = 1515,
    }

    public enum Purgevendors
    {
        Access = 1514,
    }

    public enum Purgevendoractivity
    {
        Access = 1513,
    }

    public enum Searchforduplicates
    {
        Access = 1512,
    }

    public enum Post
    {
        Access = 1511,
    }

    public enum Globallychangerecords
    {
        Access = 1510,
    }

    public enum Viewsystemstatistics
    {
        Access = 1508,
    }

    public enum Importrecords
    {
        Access = 1509,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountspayable.FENXT.Configuration
{
    public enum Expensecategories
    {
        View = 1564,

        Add = 1565,

        Edit = 1566,

        Delete = 1567,
    }

    public enum General
    {
        Access = 1533,
    }

    public enum Approvalrules
    {
        View = 1560,

        Add = 1561,

        Edit = 1562,

        Delete = 1563,
    }

    public enum Purchasetypes
    {
        View = 1556,

        Add = 1557,

        Edit = 1558,

        Delete = 1559,
    }

    public enum Terms
    {
        View = 1534,

        Add = 1535,

        Edit = 1536,

        Delete = 1537,
    }

    public enum Postinginformation
    {
        Access = 1555,
    }

    public enum Attributes
    {
        Access = 1538,
    }

    public enum Categories
    {
        View = 1551,

        Add = 1552,

        Edit = 1553,

        Delete = 1554,
    }

    public enum Defaultaccounts
    {
        Access = 1550,
    }

    public enum AgingInformation
    {
        View = 1539,

        Edit = 1540,
    }

    public enum Addresses
    {
        View = 1546,

        Add = 1547,

        Edit = 1548,

        Delete = 1549,
    }

    public enum Businessrules
    {
        Access = 1541,
    }

    public enum Miscellaneouslineitems
    {
        Access = 1545,
    }

    public enum Distribution
    {
        Access = 1544,
    }

    public enum Tables
    {
        Access = 1542,
    }

    public enum Fields
    {
        Access = 1543,
    }

    public enum Activitytypes
    {
        Manage = 2801,
    }

    public enum Salestaxitems
    {
        View = 2802,

        Add = 2803,

        Edit = 2804,

        Delete = 2805,
    }

    public enum GSTtaxIDs
    {
        View = 2806,

        Add = 2807,

        Edit = 2808,

        Delete = 2809,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountspayable.FENXT.Codetables
{
    public enum Actionstatus
    {
        Access = 1516,
    }

    public enum Staff
    {
        Access = 1530,
    }

    public enum Actiontype
    {
        Access = 1517,
    }

    public enum Shippingcodes
    {
        Access = 1529,
    }

    public enum Bankaccountnotepadtype
    {
        Access = 1518,
    }

    public enum Buyers
    {
        Access = 1519,
    }

    public enum Rejectionreason
    {
        Access = 1528,
    }

    public enum Cancellationreason
    {
        Access = 1520,
    }

    public enum Notepadtype
    {
        Access = 1527,
    }

    public enum Department
    {
        Access = 1522,
    }

    public enum Mediatype
    {
        Access = 1526,
    }

    public enum FOB
    {
        Access = 1523,
    }

    public enum Location
    {
        Access = 1525,
    }

    public enum Journal
    {
        Access = 1524,
    }

    public enum Creditcardtype
    {
        Access = 1521,
    }

    public enum Vendortype
    {
        Access = 1532,
    }

    public enum Unitofmeasure
    {
        Access = 1531,
    }

    public enum Treasurymediatype
    {
        Access = 2870,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountspayable.FENXT.Payablesprocessing
{
    public enum Payablesprocessing
    {
        Access = 1579,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountspayable.FENXT.Mail
{
    public enum Purchaseorderforms
    {
        Access = 1574,
    }

    public enum Rolodexandindexcards
    {
        Access = 1578,
    }

    public enum Envelopes
    {
        Access = 1575,
    }

    public enum Labels
    {
        Access = 1577,
    }

    public enum Labeltruncationreport
    {
        Access = 1576,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountspayable.FENXT.Export
{
    public enum Export
    {
        Access = 1573,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountspayable.FENXT.Query
{
    public enum Query
    {
        Access = 1580,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountspayable.FENXT.Dashboard
{
    public enum APquery
    {
        Access = 1568,
    }

    public enum Topvendors
    {
        Access = 1572,
    }

    public enum Agedaccountspayable
    {
        Access = 1569,
    }

    public enum PendingPOlist
    {
        Access = 1571,
    }

    public enum Invoicesduelist
    {
        Access = 1570,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountspayable.FENXT.Records
{
    public enum Vendors
    {
        View = 1581,

        Add = 1582,

        Edit = 1583,

        Delete = 1584,
    }

    public enum Activity
    {
        View = 1585,
    }

    public enum Addresses
    {
        View = 1586,

        Add = 1587,

        Edit = 1588,

        Delete = 1589,
    }

    public enum Bankinformation
    {
        View = 1592,

        Add = 1593,

        Edit = 1594,

        Delete = 1595,
    }

    public enum Vendorattributes
    {
        View = 1590,

        Edit = 1591,
    }

    public enum Vendornotes
    {
        View = 1598,

        Add = 1599,

        Edit = 1600,

        Delete = 1601,
    }

    public enum GLdistribution
    {
        View = 1596,

        Edit = 1597,
    }

    public enum Vendorpurchaseorders
    {
        View = 1603,
    }

    public enum Recurring
    {
        View = 1602,
    }

    public enum Generatepurchaseordersfromrequisitions
    {
        Access = 1699,
    }

    public enum Products
    {
        View = 1691,

        Add = 1692,

        Edit = 1693,

        Delete = 1694,
    }

    public enum Requisitions
    {
        View = 1695,

        Add = 1696,

        Edit = 1697,

        Delete = 1698,
    }

    public enum Createinvoice
    {
        Access = 1689,
    }

    public enum Createassets
    {
        Access = 1690,
    }

    public enum Receipts
    {
        View = 1684,

        Add = 1685,

        Edit = 1686,

        Delete = 1687,
    }

    public enum POlineitem
    {
        Add = 1688,
    }

    public enum ShowCRaccountnumbercolumninthelineitemdistribution
    {
        Access = 1682,
    }

    public enum Purchaseordermiscellaneousentries
    {
        Access = 1683,
    }

    public enum Media
    {
        View = 1604,

        Add = 1605,

        Edit = 1606,

        Delete = 1607,
    }

    public enum Cancelpurchaseorders
    {
        Access = 1681,
    }

    public enum Historyofchanges
    {
        View = 1612,
    }

    public enum Actions
    {
        View = 1608,

        Add = 1609,

        Edit = 1610,

        Delete = 1611,
    }

    public enum _1099distributions
    {
        Access = 1614,
    }

    public enum _1099adjustments
    {
        Access = 1613,
    }

    public enum Createinvoicesforallreceipts
    {
        Access = 1679,
    }

    public enum Closepurchaseorders
    {
        Access = 1680,
    }

    public enum Purchaseordernotes
    {
        View = 1674,

        Add = 1675,

        Edit = 1676,

        Delete = 1677,
    }

    public enum Purchaseorderreceipts
    {
        View = 1678,
    }

    public enum Purchaseorderlineitems
    {
        View = 1668,

        Add = 1669,

        Edit = 1670,

        Delete = 1671,
    }

    public enum Purchaseorderattributes
    {
        View = 1672,

        Edit = 1673,
    }

    public enum Creditmemomiscellaneousentries
    {
        Access = 1663,
    }

    public enum Purchaseorders
    {
        View = 1664,

        Add = 1665,

        Edit = 1666,

        Delete = 1667,
    }

    public enum Applycreditmemos
    {
        Access = 1661,
    }

    public enum ShowDRaccountnumbercolumninthecreditmemodistribution
    {
        Access = 1662,
    }

    public enum Vendormiscellaneousentries
    {
        Access = 1615,
    }

    public enum Creditmemonotes
    {
        View = 1657,

        Add = 1658,

        Edit = 1659,

        Delete = 1660,
    }

    public enum Creditmemos
    {
        View = 1651,

        Add = 1652,

        Edit = 1653,

        Delete = 1654,
    }

    public enum Creditmemoattributes
    {
        View = 1655,

        Edit = 1656,
    }

    public enum ShowCRaccountnumbercolumnintherecurringinvoicedistribution
    {
        Access = 1649,
    }

    public enum Recurringinvoicemiscellaneousentries
    {
        Access = 1650,
    }

    public enum Recurringinvoicenotes
    {
        View = 1644,

        Add = 1645,

        Edit = 1646,

        Delete = 1647,
    }

    public enum Generaterecurringinvoices
    {
        Access = 1648,
    }

    public enum Recurringinvoiceattributes
    {
        View = 1642,

        Edit = 1643,
    }

    public enum Summaryinformation
    {
        View = 1616,
    }

    public enum Invoices
    {
        View = 1617,

        Add = 1618,

        Edit = 1619,

        Delete = 1620,
    }

    public enum Invoiceschedule
    {
        View = 1641,
    }

    public enum PaymentsCredits
    {
        View = 1621,
    }

    public enum Recurringinvoices
    {
        View = 1637,

        Add = 1638,

        Edit = 1639,

        Delete = 1640,
    }

    public enum Invoiceattributes
    {
        View = 1622,

        Edit = 1623,
    }

    public enum Invoicemiscellaneousentries
    {
        Access = 1636,
    }

    public enum Invoiceadjustments
    {
        View = 1628,

        Add = 1629,

        Edit = 1630,

        Delete = 1631,
    }

    public enum Invoicenotes
    {
        View = 1624,

        Add = 1625,

        Edit = 1626,

        Delete = 1627,
    }

    public enum ShowCRaccountnumbercolumnintheinvoicedistribution
    {
        Access = 1635,
    }

    public enum Invoicerequests
    {
        View = 1632,
    }

    public enum Schedulepayments
    {
        Access = 1634,
    }

    public enum Changeinvoicestatus
    {
        Access = 1633,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Payables.Record
{
    public enum Vendors
    {
        View = 1700,

        AddEdit = 1701,

        Delete = 1702,
    }

    public enum Invoices
    {
        View = 1703,

        AddEdit = 1704,

        Delete = 1705,

        Approve = 2672,
    }

    public enum Creditmemos
    {
        View = 1706,

        AddEdit = 1707,

        Delete = 2045,

        Apply = 2714,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountsreceivable.FENXT.Administration
{
    public enum Mergeclients
    {
        Access = 1762,
    }

    public enum Createautomaticpayments
    {
        Access = 1756,
    }

    public enum Viewsystemstatistics
    {
        Access = 1757,
    }

    public enum Globallychangerecords
    {
        Access = 1759,
    }

    public enum Post
    {
        Access = 1760,
    }

    public enum Searchforduplicates
    {
        Access = 1761,
    }

    public enum Importrecords
    {
        Access = 1758,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Payables.TCSPM.Record
{
    public enum Vendors
    {
        View = 1747,

        AddEdit = 1748,

        Delete = 1749,

        ViewtaxID = 2626,

        AddEdittaxID = 2627,
    }

    public enum Invoices
    {
        View = 1750,

        AddEdit = 1751,

        Delete = 1752,

        Approve = 2673,
    }

    public enum Creditmemos
    {
        View = 1753,

        AddEdit = 1754,

        Delete = 1755,

        Apply = 2715,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountspayable.FENXT.Reports
{
    public enum Bankprofilereport
    {
        Access = 1709,
    }

    public enum Bankreconciliationreport
    {
        Access = 1710,
    }

    public enum Bankregisterreport
    {
        Access = 1711,
    }

    public enum Customreports
    {
        Access = 1712,
    }

    public enum Receiptreport
    {
        Access = 1736,
    }

    public enum Invoiceaccountdistributionreport
    {
        Access = 1713,
    }

    public enum Invoiceprojectdistributionreport
    {
        Access = 1722,
    }

    public enum Agedaccountspayablereport
    {
        Access = 1714,
    }

    public enum Purchaseorderhistoryreport
    {
        Access = 1734,
    }

    public enum Cashrequirementsreport
    {
        Access = 1715,
    }

    public enum Purchaseorderdetailreport
    {
        Access = 1733,
    }

    public enum Productprofilereport
    {
        Access = 1732,
    }

    public enum Recurringinvoicereport
    {
        Access = 1723,
    }

    public enum Creditmemoreport
    {
        Access = 1716,
    }

    public enum Transactionregister
    {
        Access = 1724,
    }

    public enum Pivotreports
    {
        Access = 1725,
    }

    public enum Holdpaymentreport
    {
        Access = 1717,
    }

    public enum Overdueshipmentsreport
    {
        Access = 1730,
    }

    public enum Productlistreport
    {
        Access = 1731,
    }

    public enum Invoiceexpenseallocationreport
    {
        Access = 1718,
    }

    public enum Anticipateddeliveriesreport
    {
        Access = 1726,
    }

    public enum Blanketpurchaseordersreport
    {
        Access = 1727,
    }

    public enum Invoicegenerationreport
    {
        Access = 1719,
    }

    public enum Encumbrancereport
    {
        Access = 1728,
    }

    public enum VendorYeartoDateanalysisreport
    {
        Access = 1746,
    }

    public enum Vendorprofilereport
    {
        Access = 1745,
    }

    public enum Vendoractivityreport
    {
        Access = 1744,
    }

    public enum Cashdisbursementjournals
    {
        Access = 1743,
    }

    public enum _1099activityreport
    {
        Access = 1742,
    }

    public enum Openinvoicereconciliationreport
    {
        Access = 1741,
    }

    public enum Accountdistributionreconciliationreport
    {
        Access = 1740,
    }

    public enum Requisitionprofilereport
    {
        Access = 1739,
    }

    public enum Invoicehistoryreport
    {
        Access = 1720,
    }

    public enum Openinvoicereport
    {
        Access = 1721,
    }

    public enum Requisitionlist
    {
        Access = 1738,
    }

    public enum Requisitiondetailreport
    {
        Access = 1737,
    }

    public enum Purchaseorderregister
    {
        Access = 1735,
    }

    public enum Openpurchaseordersreport
    {
        Access = 1729,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountsreceivable.FENXT.Codetables
{
    public enum Unitofmeasure
    {
        Access = 1793,
    }

    public enum Territory
    {
        Access = 1792,
    }

    public enum Shippingcodes
    {
        Access = 1789,
    }

    public enum Serviceprovider
    {
        Access = 1788,
    }

    public enum Staff
    {
        Access = 1790,
    }

    public enum Salestaxentity
    {
        Access = 1787,
    }

    public enum Religion
    {
        Access = 1786,
    }

    public enum Addresstype
    {
        Access = 1765,
    }

    public enum Actionstatus
    {
        Access = 1763,
    }

    public enum Approvedby
    {
        Access = 1766,
    }

    public enum Actiontype
    {
        Access = 1764,
    }

    public enum Relationship
    {
        Access = 1785,
    }

    public enum Bankaccountnotepadtype
    {
        Access = 1767,
    }

    public enum Clientstatus
    {
        Access = 1769,
    }

    public enum Creditcardtype
    {
        Access = 1771,
    }

    public enum Buyers
    {
        Access = 1768,
    }

    public enum Enteredby
    {
        Access = 1773,
    }

    public enum Clienttype
    {
        Access = 1770,
    }

    public enum Financerate
    {
        Access = 1775,
    }

    public enum Creditrating
    {
        Access = 1772,
    }

    public enum Industry
    {
        Access = 1777,
    }

    public enum Ethnicity
    {
        Access = 1774,
    }

    public enum Items
    {
        Access = 1779,
    }

    public enum FOB
    {
        Access = 1776,
    }

    public enum Mediatype
    {
        Access = 1781,
    }

    public enum Itemcategory
    {
        Access = 1778,
    }

    public enum Otherpaymenttype
    {
        Access = 1783,
    }

    public enum Journal
    {
        Access = 1780,
    }

    public enum Paymentsource
    {
        Access = 1784,
    }

    public enum Notepadtype
    {
        Access = 1782,
    }

    public enum Statementcode
    {
        Access = 1791,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountsreceivable.FENXT.Export
{
    public enum Export
    {
        Access = 1814,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountsreceivable.FENXT.Configuration
{
    public enum Defaultaccounts
    {
        Access = 1806,
    }

    public enum Statementinformation
    {
        Access = 1805,
    }

    public enum General
    {
        Access = 1794,
    }

    public enum Attributes
    {
        Access = 1796,
    }

    public enum Terms
    {
        Access = 1795,
    }

    public enum Businessrules
    {
        Access = 1798,
    }

    public enum Aginginformation
    {
        Access = 1797,
    }

    public enum Fields
    {
        Access = 1800,
    }

    public enum Tables
    {
        Access = 1799,
    }

    public enum AddresseeSalutations
    {
        Access = 1803,
    }

    public enum Postinginformation
    {
        Access = 1804,
    }

    public enum Distribution
    {
        Access = 1801,
    }

    public enum Productsandbillingitems
    {
        Access = 1802,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountsreceivable.FENXT.Notes
{
    public enum Notes
    {
        Access = 1825,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountsreceivable.FENXT.Dashboard
{
    public enum Accountsreceivablequery
    {
        Access = 1813,
    }

    public enum Cashreceiptsanalysis
    {
        Access = 1812,
    }

    public enum Serviceandsalestrendanalysis
    {
        Access = 1811,
    }

    public enum Agedaccountsreceivable
    {
        Access = 1807,
    }

    public enum Topclients
    {
        Access = 1808,
    }

    public enum Revenueandcollectionanalysis
    {
        Access = 1809,
    }

    public enum Serviceandsalesanalysis
    {
        Access = 1810,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountsreceivable.FENXT.Query
{
    public enum Query
    {
        Access = 1826,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountsreceivable.FENXT.Receivablesprocessing
{
    public enum Receivablesprocessing
    {
        Access = 1827,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountsreceivable.FENXT.Mail
{
    public enum ARreceipts
    {
        Access = 1815,
    }

    public enum Debitmemos
    {
        Access = 1817,
    }

    public enum Creditmemos
    {
        Access = 1816,
    }

    public enum Singlestatement
    {
        Access = 1819,
    }

    public enum Invoices
    {
        Access = 1818,
    }

    public enum Statements
    {
        Access = 1820,
    }

    public enum Labeltruncationreport
    {
        Access = 1822,
    }

    public enum Rolodexandindexcards
    {
        Access = 1824,
    }

    public enum Labels
    {
        Access = 1823,
    }

    public enum Envelopes
    {
        Access = 1821,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountsreceivable.FENXT.Records
{
    public enum Clients
    {
        Delete = 1831,

        Add = 1829,

        Edit = 1830,

        View = 1828,
    }

    public enum Addresses
    {
        View = 1832,

        Add = 1833,

        Edit = 1834,

        Delete = 1835,
    }

    public enum Notes
    {
        View = 1838,

        Add = 1839,

        Edit = 1840,

        Delete = 1841,
    }

    public enum Actions
    {
        View = 1846,

        Add = 1847,

        Edit = 1848,

        Delete = 1849,
    }

    public enum Payers
    {
        View = 1854,

        Add = 1855,

        Edit = 1856,

        Delete = 1857,
    }

    public enum EFTbankinformation
    {
        View = 1862,

        Add = 1863,

        Edit = 1864,

        Delete = 1865,
    }

    public enum Automaticpayments
    {
        View = 1867,

        Add = 1868,

        Edit = 1869,

        Delete = 1870,

        Create = 1871,
    }

    public enum Activity
    {
        View = 1873,
    }

    public enum Defaults
    {
        View = 1878,

        Edit = 1879,
    }

    public enum Attributes
    {
        View = 1836,

        Edit = 1837,
    }

    public enum Voiddeposit
    {
        Access = 1881,
    }

    public enum Media
    {
        View = 1842,

        Add = 1843,

        Edit = 1844,

        Delete = 1845,
    }

    public enum Paymentattributesandnotes
    {
        View = 1886,

        Edit = 1887,
    }

    public enum Relationships
    {
        View = 1850,

        Add = 1851,

        Edit = 1852,

        Delete = 1853,
    }

    public enum Createautomaticpayments
    {
        Access = 1892,
    }

    public enum Statements
    {
        View = 1858,

        Add = 1859,

        Edit = 1860,

        Delete = 1861,
    }

    public enum Addandeditmiscellaneouspaymententries
    {
        Access = 1895,
    }

    public enum Recurring
    {
        View = 1866,
    }

    public enum Misccomponents
    {
        View = 1897,

        Add = 1898,

        Edit = 1899,

        Delete = 1900,
    }

    public enum Historyofcharges
    {
        View = 1872,
    }

    public enum Miscadjustments
    {
        View = 1903,

        Add = 1904,

        Edit = 1905,

        Delete = 1906,
    }

    public enum Deposits
    {
        View = 1874,

        Add = 1875,

        Edit = 1876,

        Delete = 1877,
    }

    public enum Applications
    {
        Edit = 1908,
    }

    public enum Receipts
    {
        View = 1880,
    }

    public enum Chargeadjustments
    {
        View = 1913,

        Add = 1914,

        Edit = 1915,

        Delete = 1916,
    }

    public enum Payments
    {
        Delete = 1885,

        View = 1882,

        Add = 1883,

        Edit = 1884,
    }

    public enum Calculatefinanceandlatecharges
    {
        Access = 1919,
    }

    public enum Paymentadjustments
    {
        View = 1888,

        Add = 1889,

        Edit = 1890,

        Delete = 1891,
    }

    public enum Addandeditmiscellaneousentries
    {
        Access = 1907,
    }

    public enum Voidpayment
    {
        Access = 1893,
    }

    public enum ShowDRaccountnumbercolumnindistribution
    {
        Access = 1922,
    }

    public enum Creditcarddetails
    {
        Access = 1896,
    }

    public enum Invoices
    {
        View = 1924,

        Add = 1925,

        Edit = 1926,

        Delete = 1927,
    }

    public enum Miscattributesandnotes
    {
        View = 1901,

        Edit = 1902,
    }

    public enum Invoiceattributesandnotes
    {
        View = 1930,

        Edit = 1931,
    }

    public enum Redistributepayment
    {
        Access = 1894,
    }

    public enum Invoicelineitems
    {
        Add = 1934,

        Delete = 1936,

        View = 1933,

        Edit = 1935,
    }

    public enum Charges
    {
        Delete = 1912,

        View = 1909,

        Add = 1910,

        Edit = 1911,

        Viewdistributions = 2838,

        Managedistributions = 2839,
    }

    public enum Invoicelineitemnotes
    {
        View = 1941,

        Edit = 1942,
    }

    public enum Chargeattributesandnotes
    {
        View = 1917,

        Edit = 1918,
    }

    public enum Invoiceschedule
    {
        View = 1965,
    }

    public enum Reverseascredit
    {
        Access = 1920,
    }

    public enum Addandeditmiscellaneousrecurringinvoiceentries
    {
        Access = 1968,
    }

    public enum Markchargesashiddenonstatements
    {
        Access = 1921,
    }

    public enum Addandeditmiscellaneouschargeentries
    {
        Access = 1923,
    }

    public enum Credits
    {
        Delete = 1973,

        View = 1970,

        Add = 1971,

        Edit = 1972,

        Viewdistributions = 2840,

        Managedistributions = 2841,
    }

    public enum Viewrefundcheck
    {
        Access = 1994,
    }

    public enum PaymentsCredits
    {
        View = 1928,

        Edit = 1929,
    }

    public enum Creditattributesandnotes
    {
        View = 1978,

        Edit = 1979,
    }

    public enum Reverseasreturn
    {
        Access = 1932,
    }

    public enum ShowCRaccountnumberinthedistribution
    {
        Access = 1981,
    }

    public enum Addandeditmiscellaneouscreditentries
    {
        Access = 1982,
    }

    public enum Invoicelineitemadjustments
    {
        View = 1937,

        Add = 1938,

        Edit = 1939,

        Delete = 1940,
    }

    public enum Refunds
    {
        View = 1983,

        Add = 1984,

        Edit = 1985,

        Delete = 1986,
    }

    public enum Addandeditmiscellaneousinvoicelineitementries
    {
        Access = 1943,
    }

    public enum Refundadjustments
    {
        View = 1987,

        Add = 1988,

        Edit = 1989,

        Delete = 1990,
    }

    public enum Recurringinvoiceattributesandnotes
    {
        View = 1966,

        Edit = 1967,
    }

    public enum Refundattributesandnotes
    {
        View = 1991,

        Edit = 1992,
    }

    public enum Generateinvoices
    {
        Access = 1969,
    }

    public enum Createrefundcheck
    {
        Access = 1993,
    }

    public enum Creditadjustments
    {
        View = 1974,

        Add = 1975,

        Edit = 1976,

        Delete = 1977,
    }

    public enum Markcreditsashiddenonstatements
    {
        Access = 1980,
    }

    public enum Addandeditmiscellaneousrefundentries
    {
        Access = 1995,
    }

    public enum Returnattributesandnotes
    {
        View = 1948,

        Edit = 1949,
    }

    public enum Returnlineitems
    {
        Edit = 1952,

        Add = 1951,

        Delete = 1953,

        View = 1950,
    }

    public enum Returnlineitemadjustments
    {
        View = 1954,

        Add = 1955,

        Edit = 1956,

        Delete = 1957,
    }

    public enum Returnlineitemnotes
    {
        View = 1958,

        Edit = 1959,
    }

    public enum Addandeditmiscellaneousreturnlineitementries
    {
        Access = 1960,
    }

    public enum Returns
    {
        View = 1944,

        Add = 1945,

        Edit = 1946,

        Delete = 1947,
    }

    public enum Recurringinvoices
    {
        View = 1961,

        Add = 1962,

        Edit = 1963,

        Delete = 1964,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountsreceivable.FENXT.Reports
{
    public enum ActionListing
    {
        Access = 1996,
    }

    public enum Actionsummaryreport
    {
        Access = 1997,
    }

    public enum Actionsbyassociationreport
    {
        Access = 1998,
    }

    public enum Agedaccountsreceivablereport
    {
        Access = 1999,
    }

    public enum Openitemreport
    {
        Access = 2000,
    }

    public enum Serviceandsalestrendanalysisreport
    {
        Access = 2002,
    }

    public enum Clientaccountactivityreport
    {
        Access = 2004,
    }

    public enum Clientaccountbalancereport
    {
        Access = 2005,
    }

    public enum Clientprofilereport
    {
        Access = 2006,
    }

    public enum Unappliedcreditreport
    {
        Access = 2025,
    }

    public enum Clientstatisticsreport
    {
        Access = 2007,
    }

    public enum Transactionlists
    {
        Access = 2024,
    }

    public enum Cashreceiptsreport
    {
        Access = 2009,
    }

    public enum Customreports
    {
        Access = 2008,
    }

    public enum Depositreport
    {
        Access = 2011,
    }

    public enum Depositlist
    {
        Access = 2010,
    }

    public enum Productandbillingitemlist
    {
        Access = 2013,
    }

    public enum Pivotreports
    {
        Access = 2012,
    }

    public enum Agedaccountsreceivable
    {
        Access = 2016,
    }

    public enum Productandbillingitemreport
    {
        Access = 2014,
    }

    public enum Openitemreconciliationreport
    {
        Access = 2017,
    }

    public enum Accountdistributionreconciliationreport
    {
        Access = 2015,
    }

    public enum EFTreport
    {
        Access = 2019,
    }

    public enum Accountdistributionreport
    {
        Access = 2018,
    }

    public enum Recurringinvoicereport
    {
        Access = 2022,
    }

    public enum Projectdistributionreport
    {
        Access = 2021,
    }

    public enum Salestaxreport
    {
        Access = 2023,
    }

    public enum Clientaccountactivitylist
    {
        Access = 2003,
    }

    public enum Invoicereport
    {
        Access = 2020,
    }

    public enum Serviceandsalesanalysisreport
    {
        Access = 2001,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Cashreceipts.FENXT.Administration
{
    public enum Viewsystemstatistics
    {
        Access = 2026,
    }

    public enum Importrecords
    {
        Access = 2027,
    }

    public enum Post
    {
        Approve = 2659,

        Delete = 2660,

        Access = 2029,
    }

    public enum Globallychangerecords
    {
        Access = 2028,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Cashreceipts.FENXT.Mail
{
    public enum CRreceipts
    {
        Access = 2046,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Cashreceipts.FENXT.Codetables
{
    public enum Bankaccountnotepadtype
    {
        Access = 2030,
    }

    public enum Category
    {
        Access = 2031,
    }

    public enum Ethnicity
    {
        Access = 2033,
    }

    public enum Creditcardtype
    {
        Access = 2032,
    }

    public enum Journal
    {
        Access = 2034,
    }

    public enum Otherpaymenttype
    {
        Access = 2035,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Cashreceipts.FENXT.Configuration
{
    public enum General
    {
        Access = 2036,
    }

    public enum Attributes
    {
        Access = 2037,
    }

    public enum Distribution
    {
        Access = 2040,
    }

    public enum Postinginformation
    {
        Access = 2041,
    }

    public enum Tables
    {
        Access = 2039,
    }

    public enum Businessrules
    {
        Access = 2038,
    }

    public enum Settings
    {
        Manage = 2705,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Cashreceipts.FENXT.Query
{
    public enum Query
    {
        Access = 2047,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Cashreceipts.FENXT.Dashboard
{
    public enum Cashreceiptsquery
    {
        Access = 2043,
    }

    public enum Cashreceiptsanalysis
    {
        Access = 2042,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Cashreceipts.FENXT.Export
{
    public enum Export
    {
        Access = 2044,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Cashreceipts.FENXT.Records
{
    public enum Workflow
    {
        Movepayments = 2622,

        Approvedeposits = 2623,
    }

    public enum Deposits
    {
        Edit = 2051,

        Delete = 2052,

        Add = 2050,

        View = 2049,
    }

    public enum Defaults
    {
        View = 2053,

        Edit = 2054,
    }

    public enum Voiddeposit
    {
        Access = 2056,
    }

    public enum Receipts
    {
        View = 2055,
    }

    public enum Payments
    {
        Delete = 2060,

        Add = 2058,

        Edit = 2059,

        View = 2057,
    }

    public enum Attributesnotes
    {
        View = 2061,

        Edit = 2062,
    }

    public enum Adjustments
    {
        View = 2063,

        Add = 2064,

        Edit = 2065,

        Delete = 2066,
    }

    public enum Voidpayment
    {
        Access = 2067,
    }

    public enum Addandeditmiscellaneousentries
    {
        Access = 2068,
    }

    public enum Creditcarddetails
    {
        Access = 2069,
    }

    public enum Movepayments
    {
        Access = 2647,
    }

    public enum Approvedeposits
    {
        Access = 2648,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Cashreceipts.FENXT.Reports
{
    public enum Projectdistributionreport
    {
        Access = 2076,
    }

    public enum Accountdistributionreport
    {
        Access = 2075,
    }

    public enum Pivotreport
    {
        Access = 2074,
    }

    public enum Depositreport
    {
        Access = 2073,
    }

    public enum Depositlist
    {
        Access = 2072,
    }

    public enum Cashreceiptsreport
    {
        Access = 2071,
    }

    public enum Customreport
    {
        Access = 2070,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Cashreceipts.FENXT.Receiptsprocessing
{
    public enum Receiptsprocessing
    {
        Access = 2048,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fixedassets.FENXT.Administration
{
    public enum Assetinventory
    {
        Access = 2084,
    }

    public enum Switchtomidquarterconvention
    {
        Access = 2083,
    }

    public enum Importrecords
    {
        Access = 2078,
    }

    public enum Viewsystemstatistics
    {
        Access = 2077,
    }

    public enum Purgeassets
    {
        Access = 2082,
    }

    public enum Searchforduplicates
    {
        Access = 2081,
    }

    public enum Post
    {
        Access = 2080,
    }

    public enum Globallychangerecords
    {
        Access = 2079,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fixedassets.FENXT.Export
{
    public enum Export
    {
        Access = 2120,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fixedassets.FENXT.Configuration
{
    public enum Postinginformation
    {
        Access = 2115,
    }

    public enum General
    {
        Access = 2096,
    }

    public enum Defaultaccounts
    {
        Access = 2114,
    }

    public enum Attributes
    {
        Access = 2097,
    }

    public enum Fields
    {
        Access = 2113,
    }

    public enum Depreciationyears
    {
        View = 2098,

        Add = 2099,

        Edit = 2100,

        Delete = 2101,
    }

    public enum Customdepreciationschedules
    {
        View = 2102,

        Add = 2103,

        Edit = 2104,

        Delete = 2105,
    }

    public enum Tables
    {
        Access = 2112,
    }

    public enum Assetclasses
    {
        View = 2106,

        Add = 2107,

        Edit = 2108,

        Delete = 2109,
    }

    public enum Businessrules
    {
        Access = 2111,
    }

    public enum Distribution
    {
        Access = 2110,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fixedassets.FENXT.Assetsprocessing
{
    public enum Assetsprocessing
    {
        Access = 2085,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fixedassets.FENXT.Codetables
{
    public enum User
    {
        Access = 2095,
    }

    public enum Notepadtype
    {
        Access = 2094,
    }

    public enum Actiontype
    {
        Access = 2087,
    }

    public enum Mediatype
    {
        Access = 2093,
    }

    public enum Assetdescriptions
    {
        Access = 2088,
    }

    public enum Location
    {
        Access = 2092,
    }

    public enum Department
    {
        Access = 2089,
    }

    public enum Journal
    {
        Access = 2091,
    }

    public enum Disposalmethod
    {
        Access = 2090,
    }

    public enum Actionstatus
    {
        Access = 2086,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fixedassets.FENXT.Mail
{
    public enum Labeltruncationreport
    {
        Access = 2121,
    }

    public enum Labels
    {
        Access = 2122,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fixedassets.FENXT.Dashboard
{
    public enum Topassets
    {
        Access = 2119,
    }

    public enum Projecteddeprecation
    {
        Access = 2117,
    }

    public enum FAQuery
    {
        Access = 2116,
    }

    public enum Acquisition
    {
        Access = 2118,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fixedassets.FENXT.Query
{
    public enum Query
    {
        Access = 2123,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fixedassets.FENXT.Records
{
    public enum Assets
    {
        View = 2124,

        Add = 2125,

        Edit = 2126,

        Delete = 2127,
    }

    public enum Addandeditmiscellaneousentries
    {
        Access = 2157,
    }

    public enum Activity
    {
        View = 2128,
    }

    public enum Location
    {
        View = 2134,

        Add = 2135,

        Edit = 2136,

        Delete = 2137,
    }

    public enum Actions
    {
        View = 2130,

        Add = 2131,

        Edit = 2132,

        Delete = 2133,
    }

    public enum Projecteddeprecation
    {
        View = 2129,
    }

    public enum Adjustments
    {
        View = 2154,

        Add = 2155,

        Delete = 2156,
    }

    public enum Transactions
    {
        View = 2150,

        Add = 2151,

        Edit = 2152,

        Delete = 2153,
    }

    public enum Attributes
    {
        View = 2138,

        Edit = 2139,
    }

    public enum Calculatedepreciation
    {
        Access = 2149,
    }

    public enum Notes
    {
        View = 2144,

        Add = 2145,

        Edit = 2146,

        Delete = 2147,
    }

    public enum Historyofchanges
    {
        View = 2148,
    }

    public enum Media
    {
        View = 2140,

        Add = 2141,

        Edit = 2142,

        Delete = 2143,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fixedassets.FENXT.Reports
{
    public enum Actionsummaryreport
    {
        Access = 2159,
    }

    public enum Actionlisting
    {
        Access = 2158,
    }

    public enum Yeartodatedepreciationreport
    {
        Access = 2177,
    }

    public enum Projectdepreciationreport
    {
        Access = 2176,
    }

    public enum Projectdistributionreport
    {
        Access = 2175,
    }

    public enum Actionsbyassociationreport
    {
        Access = 2160,
    }

    public enum Form4562depreciationsummaryreport
    {
        Access = 2174,
    }

    public enum Acquisitionreport
    {
        Access = 2161,
    }

    public enum Disposalgainlossreport
    {
        Access = 2173,
    }

    public enum Assetlisting
    {
        Access = 2162,
    }

    public enum Depreciationsummaryreport
    {
        Access = 2172,
    }

    public enum Accountdistributionreport
    {
        Access = 2170,
    }

    public enum Assettransactionreport
    {
        Access = 2171,
    }

    public enum Assetlocationreport
    {
        Access = 2163,
    }

    public enum Pivotreport
    {
        Access = 2169,
    }

    public enum Assetmovehistory
    {
        Access = 2164,
    }

    public enum Assetprofilereport
    {
        Access = 2165,
    }

    public enum Bookvaluereport
    {
        Access = 2166,
    }

    public enum Midquarterconventiontestreport
    {
        Access = 2167,
    }

    public enum Customreport
    {
        Access = 2168,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Generalledger.FENXT.Administration
{
    public enum Updatefundtransactionrequirements
    {
        Access = 2188,
    }

    public enum Enterbeginningbalance
    {
        Access = 2186,
    }

    public enum Lockbeginningbalance
    {
        Access = 2187,
    }

    public enum Viewsystemstatistics
    {
        Access = 2178,
    }

    public enum Closefiscalyear
    {
        Access = 2185,
    }

    public enum Globallychangerecords
    {
        Access = 2180,
    }

    public enum Importrecords
    {
        Access = 2179,
    }

    public enum Searchforduplicates
    {
        Access = 2182,
    }

    public enum Summarizefiscalyears
    {
        Access = 2183,
    }

    public enum Purgefiscalyears
    {
        Access = 2184,
    }

    public enum Post
    {
        Access = 2181,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Generalledger.FENXT.Allocationmanagement
{
    public enum Rates
    {
        View = 2193,

        Add = 2194,

        Edit = 2195,

        Delete = 2196,
    }

    public enum Allocations
    {
        View = 2189,

        Add = 2190,

        Edit = 2191,

        Delete = 2192,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Generalledger.FENXT.Codetables
{
    public enum Workingcapital
    {
        Access = 2230,
    }

    public enum Actionstatus
    {
        Access = 2197,
    }

    public enum Transactioncodes5
    {
        Access = 2229,
    }

    public enum Actiontype
    {
        Access = 2198,
    }

    public enum Transactioncodes4
    {
        Access = 2228,
    }

    public enum Transactioncodes3
    {
        Access = 2227,
    }

    public enum Bankaccountnotepadtype
    {
        Access = 2199,
    }

    public enum Cashflow
    {
        Access = 2200,
    }

    public enum Department
    {
        Access = 2202,
    }

    public enum Class
    {
        Access = 2201,
    }

    public enum Endowmentmanager
    {
        Access = 2203,
    }

    public enum Grantmanager
    {
        Access = 2205,
    }

    public enum Grantexpensetypes
    {
        Access = 2204,
    }

    public enum Grantstatus
    {
        Access = 2206,
    }

    public enum Projectstatus
    {
        Access = 2216,
    }

    public enum Granttypes
    {
        Access = 2207,
    }

    public enum Projecttypes
    {
        Access = 2217,
    }

    public enum Reportcategory
    {
        Access = 2219,
    }

    public enum ScenarioId
    {
        Access = 2220,
    }

    public enum Ratetype
    {
        Access = 2218,
    }

    public enum Service
    {
        Access = 2222,
    }

    public enum Taxexempt
    {
        Access = 2224,
    }

    public enum Series
    {
        Access = 2221,
    }

    public enum Transactioncodes1
    {
        Access = 2225,
    }

    public enum Location
    {
        Access = 2209,
    }

    public enum Journal
    {
        Access = 2208,
    }

    public enum Notepadtype
    {
        Access = 2211,
    }

    public enum Mediatype
    {
        Access = 2210,
    }

    public enum Projectlocation
    {
        Access = 2215,
    }

    public enum Transactioncodes2
    {
        Access = 2226,
    }

    public enum Programdirector
    {
        Access = 2212,
    }

    public enum Projectdepartment
    {
        Access = 2213,
    }

    public enum Projectdivision
    {
        Access = 2214,
    }

    public enum Statementcycle
    {
        Access = 2223,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Generalledger.FENXT.Dashboard
{
    public enum Statementofcashflows
    {
        Access = 2284,
    }

    public enum Accountsoverbudget
    {
        Access = 2276,
    }

    public enum Projecttracking
    {
        Access = 2283,
    }

    public enum Percentageofrevenues
    {
        Access = 2282,
    }

    public enum Percentageofexpenses
    {
        Access = 2281,
    }

    public enum Balancesheet
    {
        Access = 2277,
    }

    public enum Incomestatement
    {
        Access = 2280,
    }

    public enum Generalledgerquery
    {
        Access = 2279,
    }

    public enum Financialratios
    {
        Access = 2278,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Generalledger.FENXT.Configuration
{
    public enum Accountcodes
    {
        View = 2231,

        Add = 2232,

        Edit = 2233,

        Delete = 2234,
    }

    public enum Accountcodefield
    {
        Access = 2235,
    }

    public enum Accountstructure
    {
        View = 2239,

        Edit = 2240,

        Delete = 2241,
    }

    public enum Invalidsegmentcombinations
    {
        View = 2245,

        Edit = 2246,

        Delete = 2247,
    }

    public enum Accountsetup
    {
        View = 2236,

        Edit = 2237,

        Delete = 2238,
    }

    public enum Categorydefinitions
    {
        View = 2242,

        Edit = 2243,

        Delete = 2244,
    }

    public enum Feeschedules
    {
        View = 2268,

        Add = 2269,

        Edit = 2270,

        Delete = 2271,
    }

    public enum Defaultdescription
    {
        View = 2248,

        Edit = 2249,

        Delete = 2250,
    }

    public enum General
    {
        Access = 2266,
    }

    public enum Allocationpools
    {
        View = 2272,

        Add = 2273,

        Edit = 2274,

        Delete = 2275,
    }

    public enum Lengthensetment
    {
        Access = 2252,
    }

    public enum Transactioncodes
    {
        Edit = 2267,
    }

    public enum Businessrules
    {
        Access = 2254,
    }

    public enum Addsegment
    {
        Access = 2251,
    }

    public enum Fields
    {
        Access = 2256,
    }

    public enum Attributes
    {
        Access = 2253,
    }

    public enum Reopensoftclosedperiod
    {
        Access = 2261,
    }

    public enum Distributions
    {
        Access = 2255,
    }

    public enum Funds
    {
        View = 2262,

        Add = 2263,

        Edit = 2264,

        Delete = 2265,
    }

    public enum Fiscalyears
    {
        View = 2257,

        Add = 2258,

        Edit = 2259,

        Delete = 2260,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Generalledger.FENXT.Notes
{
    public enum Notes
    {
        Access = 2297,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Generalledger.FENXT.Export
{
    public enum Export
    {
        Access = 2285,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Generalledger.FENXT.Journalentry
{
    public enum Recurringbatch
    {
        View = 2293,

        Edit = 2294,

        Create = 2295,
    }

    public enum Postbatch
    {
        Access = 2292,
    }

    public enum Allowselfapprovalofabatch
    {
        Access = 2291,
    }

    public enum Regularbatch
    {
        View = 2286,

        Edit = 2287,

        Create = 2288,

        Approve = 2289,

        Validate = 2290,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Generalledger.FENXT.Query
{
    public enum Query
    {
        Access = 2298,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Generalledger.FENXT.Ledgerprocessing
{
    public enum Ledgerprocessing
    {
        Access = 2296,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Generalledger.FENXT.Records
{
    public enum Grants
    {
        View = 2299,

        Add = 2300,

        Edit = 2301,

        Delete = 2302,
    }

    public enum Grantattributes
    {
        View = 2303,

        Edit = 2304,
    }

    public enum Grantbudget
    {
        View = 2305,
    }

    public enum Budgetadjustments
    {
        View = 2378,

        Add = 2379,
    }

    public enum Budgetnotes
    {
        Access = 2377,
    }

    public enum Grantproject
    {
        View = 2306,

        Edit = 2307,
    }

    public enum Grantreimbursement
    {
        View = 2308,

        Edit = 2309,
    }

    public enum Grantactivity
    {
        View = 2310,
    }

    public enum Clearbudget
    {
        Access = 2376,
    }

    public enum Deletescenarios
    {
        Access = 2375,
    }

    public enum Finalizescenarios
    {
        Access = 2374,
    }

    public enum Grantmedia
    {
        View = 2311,

        Add = 2312,

        Edit = 2313,

        Delete = 2314,
    }

    public enum Grantactions
    {
        View = 2315,

        Add = 2316,

        Edit = 2317,

        Delete = 2318,
    }

    public enum Increasedecreasebudgets
    {
        Access = 2372,
    }

    public enum Mergescenarios
    {
        Access = 2373,
    }

    public enum Copyforecastbudgets
    {
        Access = 2371,
    }

    public enum Changepreventpostingdate
    {
        View = 2366,
    }

    public enum Budget
    {
        View = 2367,

        Add = 2368,

        Edit = 2369,

        Delete = 2370,
    }

    public enum Activatedeactivateprojects
    {
        Access = 2365,
    }

    public enum Projectnotes
    {
        View = 2360,

        Add = 2361,

        Edit = 2362,

        Delete = 2363,
    }

    public enum Projecthistoryofchanges
    {
        View = 2364,
    }

    public enum Grantnotes
    {
        View = 2319,

        Add = 2320,

        Edit = 2321,

        Delete = 2322,
    }

    public enum Granthistoryofchanges
    {
        View = 2323,
    }

    public enum Projectactions
    {
        View = 2356,

        Add = 2357,

        Edit = 2358,

        Delete = 2359,
    }

    public enum Projectmedia
    {
        View = 2352,

        Add = 2353,

        Edit = 2354,

        Delete = 2355,
    }

    public enum Accounts
    {
        View = 2325,

        Add = 2326,

        Edit = 2327,

        Delete = 2328,
    }

    public enum GenerateARtransactionsforgrantexpenses
    {
        Access = 2324,
    }

    public enum Projectactivity
    {
        View = 2351,
    }

    public enum Accountbudget
    {
        View = 2331,
    }

    public enum Accountnotes
    {
        View = 2332,

        Add = 2333,

        Edit = 2334,

        Delete = 2335,
    }

    public enum Accounthistoryofchanges
    {
        View = 2338,
    }

    public enum Accountattributes
    {
        View = 2329,

        Edit = 2330,
    }

    public enum Activatedeactivateaccounts
    {
        Access = 2339,
    }

    public enum Projectattributes
    {
        View = 2344,

        Edit = 2345,
    }

    public enum Defaulttransactionattributes
    {
        View = 2336,

        Edit = 2337,
    }

    public enum Projectbudget
    {
        View = 2346,
    }

    public enum Indirectcostsinvestments
    {
        View = 2349,

        Edit = 2350,
    }

    public enum Projects
    {
        View = 2340,

        Add = 2341,

        Edit = 2342,

        Delete = 2343,
    }

    public enum Projectaccountrestrictions
    {
        View = 2347,

        Edit = 2348,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Generalledger.FENXT.Reports
{
    public enum Accountprofilereport
    {
        Access = 2380,
    }

    public enum Chartofaccountsreport
    {
        Access = 2381,
    }

    public enum Chartvalidationreport
    {
        Access = 2382,
    }

    public enum Fundprofilereport
    {
        Access = 2383,
    }

    public enum Generalledgerreport
    {
        Access = 2384,
    }

    public enum Trialbalancereport
    {
        Access = 2385,
    }

    public enum Workingcapitalschedule
    {
        Access = 2386,
    }

    public enum Allocationpoolprofilereport
    {
        Access = 2388,
    }

    public enum Budgetadjustmentsjournal
    {
        Access = 2389,
    }

    public enum Budgetadjustmentsreport
    {
        Access = 2390,
    }

    public enum Budgetdistributionreport
    {
        Access = 2391,
    }

    public enum Customreport
    {
        Access = 2392,
    }

    public enum Balancesheet
    {
        Access = 2393,
    }

    public enum Custommanagementreport
    {
        Access = 2394,
    }

    public enum Incomestatement
    {
        Access = 2395,
    }

    public enum Statementofactivities
    {
        Access = 2396,
    }

    public enum Statementofnetassetsnetassetsformat
    {
        Access = 2402,
    }

    public enum Statementofactivitiesstandardformat
    {
        Access = 2401,
    }

    public enum Statementofnetassetscombinedbalancesheet
    {
        Access = 2404,
    }

    public enum StatementofnetassetsscheduleB
    {
        Access = 2403,
    }

    public enum Statementofrevenuesexpendituresandchanges
    {
        Access = 2405,
    }

    public enum Statementofcashflows
    {
        Access = 2397,
    }

    public enum Grantbudgetvsactualreport
    {
        Access = 2407,
    }

    public enum Grantanalysisreport
    {
        Access = 2406,
    }

    public enum Projectdetailreport
    {
        Access = 2417,
    }

    public enum Projectbudgetvsactualreport
    {
        Access = 2416,
    }

    public enum Projectfinancialstatements
    {
        Access = 2418,
    }

    public enum Statementoffunctionalexpenses
    {
        Access = 2399,
    }

    public enum Statementoffinancialposition
    {
        Access = 2398,
    }

    public enum Projectprofilereport
    {
        Access = 2419,
    }

    public enum Grantreimbursementaccountsvalidationreport
    {
        Access = 2408,
    }

    public enum StatementofactivitiesscheduleB
    {
        Access = 2400,
    }

    public enum Batchdetailreport
    {
        Access = 2409,
    }

    public enum Allocationfeescheduleprofilereport
    {
        Access = 2387,
    }

    public enum Recurringbatchdetailreport
    {
        Access = 2411,
    }

    public enum Batchsummaryreport
    {
        Access = 2410,
    }

    public enum Transactionaljournal
    {
        Access = 2413,
    }

    public enum Projectactivityreport
    {
        Access = 2415,
    }

    public enum Recurringbatchsummaryreport
    {
        Access = 2412,
    }

    public enum Pivotreport
    {
        Access = 2414,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Generalledger.FENXT.Visualchartorganizer
{
    public enum Visualchartorganizer
    {
        View = 2420,

        Add = 2421,

        Edit = 2422,

        Delete = 2423,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Sharedcomponents.FENXT.Dashboard
{
    public enum Dashboardsharing
    {
        Access = 2498,
    }

    public enum Topusers
    {
        Access = 2499,
    }

    public enum Actionreminders
    {
        Access = 2500,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Sharedcomponents.FENXT.Bankaccounts
{
    public enum Createelectronicfundstransferfiles
    {
        Access = 2497,
    }

    public enum Deposit
    {
        View = 2493,

        Viewdetails = 2494,

        Edit = 2495,
    }

    public enum Viewreconciliationhistory
    {
        Access = 2492,
    }

    public enum Viewaccountbalance
    {
        Access = 2490,
    }

    public enum Paymentinformation
    {
        View = 2429,

        Edit = 2430,
    }

    public enum Bankaccounts
    {
        View = 2425,

        Add = 2426,

        Edit = 2427,

        Delete = 2428,
    }

    public enum Cleartransactionselectronically
    {
        Access = 2489,
    }

    public enum Reconcilebankaccount
    {
        Access = 2488,
    }

    public enum Createnewadjustments
    {
        Access = 2487,
    }

    public enum Createprenoteauthorizationfile
    {
        Access = 2496,
    }

    public enum Paymentadjustments
    {
        View = 2479,

        Viewdetails = 2480,

        Edit = 2481,

        Void = 2482,
    }

    public enum Depositadjustments
    {
        View = 2475,

        Viewdetails = 2476,

        Edit = 2477,

        Void = 2478,
    }

    public enum Viewbankaccountsummary
    {
        Access = 2491,
    }

    public enum Createmanualchecks
    {
        Access = 2473,
    }

    public enum Voidunusedchecks
    {
        Access = 2472,
    }

    public enum Renumberpayments
    {
        Access = 2470,
    }

    public enum Createprenoteauthorizationfiles
    {
        Access = 2469,
    }

    public enum Bankaccountlist
    {
        Access = 2424,
    }

    public enum Createpayments
    {
        Access = 2466,
    }

    public enum Createonetimechecks
    {
        Access = 2467,
    }

    public enum Depositinformation
    {
        View = 2431,

        Edit = 2432,
    }

    public enum EFTs
    {
        View = 2454,

        Viewdetails = 2455,

        Edit = 2456,

        Void = 2457,
    }

    public enum Onetimechecks
    {
        View = 2458,

        Viewdetails = 2459,

        Edit = 2460,

        Void = 2461,
    }

    public enum Transferadjustments
    {
        View = 2483,

        Viewdetails = 2484,

        Edit = 2485,

        Void = 2486,
    }

    public enum PostadjustmentstoGeneralLedger
    {
        Access = 2445,
    }

    public enum Computerchecks
    {
        View = 2446,

        Viewdetails = 2447,

        Edit = 2448,

        Void = 2449,
    }

    public enum Addandeditmiscellaneousentries
    {
        Access = 2474,
    }

    public enum ChangetransactionstatusOutstandingCleared
    {
        Access = 2442,
    }

    public enum Editelectronicsignatures
    {
        Access = 2443,
    }

    public enum Voidselectedpayments
    {
        Access = 2471,
    }

    public enum Adjustmentcategories
    {
        View = 2433,

        Add = 2434,

        Edit = 2435,

        Delete = 2436,
    }

    public enum Notes
    {
        View = 2437,

        Add = 2438,

        Edit = 2439,

        Delete = 2440,
    }

    public enum Editunwrittenonetimechecks
    {
        Access = 2468,
    }

    public enum Manualchecks
    {
        View = 2462,

        Viewdetails = 2463,

        Edit = 2464,

        Void = 2465,
    }

    public enum Bankdrafts
    {
        View = 2450,

        Viewdetails = 2451,

        Edit = 2452,

        Void = 2453,
    }

    public enum Purgevoidedtransactions
    {
        Access = 2444,
    }

    public enum Historyofchanges
    {
        View = 2441,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Sharedcomponents.FENXT.Personalinformation
{
    public enum Taxreporthistory
    {
        Access = 2516,
    }

    public enum Federaltaxreports
    {
        Access = 2515,
    }

    public enum Personalinformationdataentry
    {
        Access = 2509,
    }

    public enum Statetaxreports
    {
        Access = 2514,
    }

    public enum _1099forms
    {
        Access = 2513,
    }

    public enum Personalinformationview
    {
        Access = 2511,
    }

    public enum XAPtranscripts
    {
        Access = 2512,
    }

    public enum Personalinformationoutput
    {
        Access = 2510,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Sharedcomponents.FENXT.Notes
{
    public enum Notes
    {
        Access = 2508,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Sharedcomponents.FENXT.Queue
{
    public enum Queue
    {
        Access = 2517,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Sharedcomponents.FENXT.Validatedatabase
{
    public enum Validatedatabase
    {
        Access = 2522,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Sharedcomponents.FENXT.Fast
{
    public enum Commitrecords
    {
        Access = 2507,
    }

    public enum Datasheet
    {
        View = 2505,

        Edit = 2506,
    }

    public enum Design
    {
        View = 2501,

        Add = 2502,

        Edit = 2503,

        Delete = 2504,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Sharedcomponents.FENXT.Visualbasicforapplications
{
    public enum Visualbasicforapplications
    {
        Access = 2523,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Sharedcomponents.FENXT.Security
{
    public enum Security
    {
        Access = 2521,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Sharedconfigurationinformation.FENXT.International
{
    public enum International
    {
        Access = 2525,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Sharedtables.FENXT.Sharedtables
{
    public enum Title
    {
        Access = 2533,
    }

    public enum Suffix
    {
        Access = 2532,
    }

    public enum Suburb
    {
        Access = 2531,
    }

    public enum State
    {
        Access = 2530,
    }

    public enum Phonetype
    {
        Access = 2529,
    }

    public enum Currencytype
    {
        Access = 2528,
    }

    public enum Country
    {
        Access = 2527,
    }

    public enum City
    {
        Access = 2526,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Sharedcomponents.FENXT.Reports
{
    public enum Bankregisterreport
    {
        Access = 2520,
    }

    public enum Bankprofilereport
    {
        Access = 2518,
    }

    public enum Bankreconciliationreport
    {
        Access = 2519,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Cashreceipts.FENXT.Notes
{
    public enum Notes
    {
        Access = 2559,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Sharedconfigurationinformation.FENXT.Interfunds
{
    public enum Interfunds
    {
        Access = 2524,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.WebPortal.FENXT.Accountspayablerecords
{
    public enum Purchaseorders
    {
        View = 2534,
    }

    public enum Attributes
    {
        View = 2536,
    }

    public enum Notes
    {
        View = 2537,
    }

    public enum Lineitems
    {
        View = 2535,
    }

    public enum Requisitions
    {
        View = 2540,

        Add = 2541,

        Edit = 2542,
    }

    public enum Receipts
    {
        View = 2539,
    }

    public enum Purchaseorderreceipts
    {
        View = 2538,
    }

    public enum Invoicerequests
    {
        View = 2548,

        Add = 2549,

        Edit = 2550,

        Delete = 2551,
    }

    public enum Onetimeproducts
    {
        Add = 2547,
    }

    public enum Products
    {
        View = 2543,

        Add = 2544,

        Edit = 2545,

        Delete = 2546,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.CustomerSuccess.SUPTL.InternalToolsManagement
{
    public enum Supportal
    {
        View = 2552,

        Operate = 2553,

        Restricted = 2554,
    }

    public enum EnvironmentManager
    {
        View = 2555,

        Operate = 2556,

        Restricted = 2557,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.FENXTsupportal.SUPTL.FENXTsupportal
{
    public enum FENXTsupportal
    {
        View = 2561,

        Manage = 2562,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Accountspayable.FENXT.Notes
{
    public enum Notes
    {
        Access = 2560,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Fixedassets.FENXT.Notes
{
    public enum Notes
    {
        Access = 2558,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Analysis.Headquarters
{
    public enum Dashboards
    {
        AddEdit = 2563,

        Delete = 2564,

        View = 2565,
    }

    public enum Insights
    {
        AddEdit = 2566,

        Delete = 2567,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Analysis.ENM.Headquarters
{
    public enum Dashboards
    {
        AddEdit = 2568,

        Delete = 2569,

        View = 2570,
    }

    public enum Insights
    {
        AddEdit = 2571,

        Delete = 2572,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Dataenrichment.SUPTL.Dataenrichmentsupportal
{
    public enum Jobtracing
    {
        Read = 2575,

        Retry = 2576,
    }

    public enum Jobhistory
    {
        Read = 2577,
    }

    public enum Wealthpointdata
    {
        Read = 2578,

        Write = 2579,

        Delete = 2580,
    }

    public enum Jobfiles
    {
        Read = 2581,

        Delete = 2582,

        Copy = 2583,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Export.SUPTL.Export
{
    public enum Exportsupportal
    {
        View = 2585,

        Operate = 2586,

        Restricted = 2587,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Export.Export
{
    public enum Export
    {
        View = 2588,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Treasury.Signatures
{
    public enum Signatures
    {
        View = 2592,

        AddEdit = 2593,

        Delete = 2594,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Payables.SUPTL.Payables
{
    public enum Supportal
    {
        View = 2589,

        Operate = 2590,

        Restricted = 2591,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Financial.SUPTL.Ledgersupportal
{
    public enum Deadletterqueue
    {
        Manage = 2608,
    }

    public enum Durableorchestrations
    {
        Manage = 2609,
    }

    public enum Cosmos
    {
        Manage = 2610,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Treasury.TCSPM.Signatures
{
    public enum Signatures
    {
        View = 2598,

        AddEdit = 2599,

        Delete = 2600,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.SUPTL.Signatures
{
    public enum Supportal
    {
        View = 2595,

        Operate = 2596,

        Restricted = 2597,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Financial.SUPTL.Treasurysupportal
{
    public enum Deadletterqueue
    {
        Manage = 2617,
    }

    public enum Durableorchestrations
    {
        Manage = 2618,
    }

    public enum Cosmos
    {
        Manage = 2619,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Financial.SUPTL.FENXTextractionproxysupportal
{
    public enum Queryjobs
    {
        Request = 2604,
    }

    public enum Deadletterqueue
    {
        Manage = 2605,
    }

    public enum Durableorchestrations
    {
        Manage = 2606,
    }

    public enum Cosmos
    {
        Manage = 2607,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Financial.SUPTL.Payablessupportal
{
    public enum Deadletterqueue
    {
        Manage = 2611,
    }

    public enum Durableorchestrations
    {
        Manage = 2612,
    }

    public enum Cosmos
    {
        Manage = 2613,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.TCSPM.Websitecomponents
{
    public enum Websitecomponents
    {
        View = 2637,

        Manage = 2638,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.Payables
{
    public enum Settings
    {
        Manage = 2621,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Financial.SUPTL.Receivablessupportal
{
    public enum Deadletterqueue
    {
        Manage = 2614,
    }

    public enum Durableorchestrations
    {
        Manage = 2615,
    }

    public enum Cosmos
    {
        Manage = 2616,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Paymentssupportal.SUPTL.DLQmanagement
{
    public enum BBMSaccountcreationDLQ
    {
        View = 2628,

        Manage = 2629,

        Delete = 2630,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.TCSPM.Payables
{
    public enum Settings
    {
        Manage = 2639,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.CustomerSuccess.SUPTL.HealthChecks
{
    public enum Supportal
    {
        View = 2640,

        Operate = 2641,

        Restricted = 2642,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Highereducation.EDU.Analyze
{
    public enum Enrollmentmanagementdashboards
    {
        Admissionsoverview = 2643,

        Capacityplanning = 2645,

        Contracts = 2646,

        Applicants = 2644,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Paymentssupportal.SUPTL.Merchantservices
{
    public enum Mapping
    {
        Operate = 2649,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Financial.Administration
{
    public enum Post
    {
        Manage = 2650,

        Approve = 2651,

        Delete = 2652,

        Access = 2775,
    }

    public enum Postexternaljournals
    {
        Manage = 2653,

        Approve = 2654,

        Delete = 2655,

        Access = 2776,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Treasury.Administration
{
    public enum Post
    {
        Manage = 2656,

        Approve = 2657,

        Delete = 2658,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Permissionssupportal.SUPTL.Cosmos
{
    public enum Throughput
    {
        Manage = 2662,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Lists.EDU.Enrollmentmanagement
{
    public enum Enrollment
    {
        View = 2663,
    }

    public enum Admissions
    {
        View = 2689,
    }

    public enum Testscores
    {
        View = 2690,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Lists.EDU.Lists
{
    public enum Lists
    {
        Manage = 2664,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Financial.Settings
{
    public enum Distributionconfiguration
    {
        View = 2847,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Treasury.Codetables
{
    public enum Codetables
    {
        View = 2669,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Treasury.TCSPM.Codetables
{
    public enum Codetables
    {
        View = 2670,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Receivables.TCSPM.Codetable
{
    public enum Codetables
    {
        View = 2671,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Emailorchestratorsupportal.SUPTL.Email
{
    public enum Email
    {
        View = 2674,

        Operate = 2675,

        Restricted = 2676,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Emailorchestratorsupportal.SUPTL.Communicationservices
{
    public enum Communicationservices
    {
        View = 2677,

        Operate = 2678,

        Restricted = 2679,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Lists.EDU.Academics
{
    public enum Studentdegrees
    {
        View = 2680,
    }

    public enum Studentmajors
    {
        View = 2681,
    }

    public enum Courseenrollment
    {
        View = 2691,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.SUPTL.Websitecomponents
{
    public enum Supportal
    {
        View = 2682,

        Operate = 2683,

        Restricted = 2684,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Reports.DC.Reports
{
    public enum Staticreports
    {
        View = 2685,
    }

    public enum Explorerworkbook
    {
        View = 2889,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.POM.SUPTL.POM
{
    public enum Infinity
    {
        Operator = 2686,

        Reader = 2687,

        Admin = 2688,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Dashboards.DC.Dashboards
{
    public enum Highereducationbenchmarking
    {
        View = 2692,
    }

    public enum Nationalindex
    {
        View = 2693,
    }

    public enum Performance
    {
        View = 2694,
    }

    public enum Recurringgivingbenchmarking
    {
        View = 2695,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Analysis.Reporting
{
    public enum Dashboards
    {
        View = 2696,

        AddEdit = 2697,

        Delete = 2698,
    }

    public enum Insights
    {
        AddEdit = 2700,

        Delete = 2701,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Onlinegivingconnect.SUPTL.Onlinegivingconnect
{
    public enum Supportal
    {
        View = 2702,

        Operate = 2703,

        Restricted = 2704,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Onepageadmin.SUPTL.Customersupportportal
{
    public enum Supportal
    {
        View = 2744,

        Edit = 2745,

        Manage = 2746,
    }

    public enum Refunds
    {
        View = 2934,

        Approve = 2935,

        Reject = 2936,

        Submit = 2937,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Connect.Designations
{
    public enum DesignationrefreshfromconnectedCRM
    {
        View = 2759,

        Execute = 2760,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.RENXT.Generalinformation
{
    public enum Generalinformation
    {
        Manage = 2761,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Contributions.TCSPM.Designations
{
    public enum Designations
    {
        View = 2762,

        AddEdit = 2763,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.Websitecomponents
{
    public enum Websitecomponents
    {
        View = 2764,

        Manage = 2765,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.BBACT.Security
{
    public enum Roles
    {
        View = 2766,

        AddEdit = 2767,

        MarkInactive = 2768,

        Delete = 2769,
    }

    public enum Users
    {
        View = 2770,

        MarkInactive = 2772,

        AddEdit = 2771,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Tools.RENXT.Websitecomponents
{
    public enum Websitecomponent
    {
        View = 2773,

        Manage = 2774,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Financial.Records
{
    public enum Distributions
    {
        View = 2777,

        Manage = 2778,
    }

    public enum Batch
    {
        View = 2779,

        Createandedit = 2780,

        Approve = 2781,

        Delete = 2782,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Billing.Billing
{
    public enum Billing
    {
        Manage = 2783,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Support.Support
{
    public enum Support
    {
        Contact = 2784,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Receivables.Administration
{
    public enum Post
    {
        Access = 2786,
    }

    public enum Invoiceemaildefaults
    {
        Access = 2931,
    }

    public enum Statementemaildefaults
    {
        Access = 2932,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Receivables.Postplatform
{
    public enum Post
    {
        Access = 2811,
    }

    public enum Batch
    {
        View = 2812,

        Createandedit = 2813,

        Approve = 2814,

        Delete = 2815,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Treasury.Postplatform
{
    public enum Post
    {
        Access = 2816,
    }

    public enum Batch
    {
        View = 2817,

        Createandedit = 2818,

        Approve = 2819,

        Delete = 2820,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Receivables.TCSPM.Administration
{
    public enum Post
    {
        Access = 2821,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Billing.BBACT.Billing
{
    public enum Billing
    {
        Manage = 2833,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Support.BBACT.Support
{
    public enum Support
    {
        Contact = 2834,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.BBACT.Settings
{
    public enum General
    {
        Manage = 2836,
    }

    public enum Merchantaccount
    {
        Add = 2837,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Employeesupportal.SUPTL.Employeesupportal
{
    public enum Supportal
    {
        View = 2843,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Identity.SUPTL.Identity
{
    public enum Supportal
    {
        View = 2844,

        Operate = 2845,

        Restricted = 2846,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.CustomerSuccess.SUPTL.Hub
{
    public enum Supportal
    {
        View = 2853,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.CRMconnection
{
    public enum CompanyCRMconnection
    {
        Manage = 2854,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.TCSPM.CRMconnection
{
    public enum CRMconnection
    {
        Manage = 2855,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Datamartmanagement.SUPTL.Datamartmanagement
{
    public enum Datahealthtasks
    {
        Manage = 2857,
    }

    public enum Fundraisingsourcecontrol
    {
        Manage = 2858,
    }

    public enum Financialsourcecontrol
    {
        Manage = 2859,
    }

    public enum Educationsourcecontrol
    {
        Manage = 2860,
    }

    public enum Datamartsettings
    {
        Manage = 2861,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.RENXTtelemetry.SUPTL.RENXTtelemetry
{
    public enum RENXTtelemetry
    {
        View = 2862,

        Operate = 2863,

        Restricted = 2864,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Authentication.BBACT.Authentication
{
    public enum SingleSignOnSSO
    {
        Manage = 2865,
    }

    public enum ResolveduplicateSSOusers
    {
        Manage = 2866,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.TAPsupportal.SUPTL.Targetanalyticsproductspermissions
{
    public enum Console
    {
        View = 2867,

        Operate = 2868,

        Restricted = 2869,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.ReceivablesPreview.FENXT.Records
{
    public enum Billingitems
    {
        View = 2871,
    }

    public enum Charges
    {
        View = 2872,
    }

    public enum Credits
    {
        View = 2873,
    }

    public enum Clients
    {
        View = 2874,
    }

    public enum Invoices
    {
        View = 2875,
    }

    public enum Payments
    {
        View = 2876,
    }

    public enum Statements
    {
        View = 2877,
    }

    public enum Recurringinvoiceplans
    {
        View = 2878,
    }

    public enum Customfields
    {
        View = 2879,
    }

    public enum Deposits
    {
        View = 2880,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.CRMCP.Security
{
    public enum Roles
    {
        AddEdit = 2881,

        Delete = 2882,

        Markinactive = 2883,

        View = 2884,
    }

    public enum Users
    {
        View = 2885,

        Markinactive = 2887,

        AddEdit = 2886,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Receivables.Analysis
{
    public enum Agedreceivables
    {
        View = 2890,
    }

    public enum Openitems
    {
        View = 2891,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Contributions.Appeals
{
    public enum Appeals
    {
        View = 2892,

        Manage = 2893,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Appeals.SUPTL.Appeals
{
    public enum Supportal
    {
        View = 2894,

        Operate = 2895,

        Restricted = 2896,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Contributions.TCSPM.Appeals
{
    public enum Appeals
    {
        View = 2897,

        Manage = 2898,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.ReceivablesPreview.FENXT.Analysis
{
    public enum Revenuemanagement
    {
        View = 2899,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Emailorchestratordev.RENXT.Emailorchestrator
{
    public enum Email
    {
        View = 2900,

        AddEdit = 2901,

        Send = 2902,
    }

    public enum Settings
    {
        AddEdit = 2903,
    }

    public enum Recipients
    {
        View = 2904,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.Donationforms
{
    public enum GoogleAnalytics
    {
        Manage = 2905,
    }

    public enum Privacypolicy
    {
        Manage = 2906,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.RaisersEdgeNXTconnection
{
    public enum Fieldmappinganddefaults
    {
        Manage = 2907,
    }

    public enum Donorcoverdesignation
    {
        Manage = 2938,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Donationforms.TCSPM.Donationforms
{
    public enum Donationforms
    {
        View = 2908,

        Delete = 2910,

        AddEdit = 2909,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.TCSPM.RaisersEdgeNXTconnection
{
    public enum Fieldmappinganddefaults
    {
        Manage = 2911,
    }

    public enum Donorcoverdesignation
    {
        Manage = 2939,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.TCSPM.Donationforms
{
    public enum GoogleAnalytics
    {
        Manage = 2912,
    }

    public enum PrivacyPolicy
    {
        Manage = 2913,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Educationsupportal.SUPTL.Datahealth
{
    public enum Datahealth
    {
        Viewdatahealth = 2914,

        Managedatahealth = 2915,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Grantmaking.GRMKG.Applications
{
    public enum Manageapplications
    {
        View = 2916,
    }

    public enum Managehistoricalapplications
    {
        View = 2917,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Grantmaking.GRMKG.Forms
{
    public enum Formsmanager
    {
        View = 2918,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.CRMCloudPortal.CRMCloudPortal
{
    public enum Operator
    {
        CRMCloudPortalOperator = 2919,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Lists.EDU.Core
{
    public enum People
    {
        View = 2920,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Administration.LPT.Security
{
    public enum Roles
    {
        View = 2921,

        AddEdit = 2922,

        MarkInactive = 2923,

        Delete = 2924,
    }

    public enum Users
    {
        View = 2925,

        MarkInactive = 2927,

        AddEdit = 2926,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Marketplace.BBACT.Marketplaceapplications
{
    public enum Applications
    {
        Connect = 2928,

        Disconnect = 2929,

        Approvescopechanges = 2930,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.Contributions
{
    public enum Contributions
    {
        Manage = 2933,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Financial.FENXT.BankManagement
{
    public enum Yodlee
    {
        Connect = 2940,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Marketplacepartnerbilling.SUPTL.Marketplacepartnerbilling
{
    public enum Partnerbills
    {
        Manage = 2941,
    }

    public enum Partnerbillingservice
    {
        Operate = 2942,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Surveys.DC.Surveys
{
    public enum Datatranslationsurvey
    {
        View = 2943,

        Edit = 2944,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Recurringgiftconversion.Recurringgiftconversion
{
    public enum Recurringgiftconversion
    {
        View = 2950,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Recurringgiftconversion.SUPTL.Recurringgiftconversion
{
    public enum Recurringgiftconversionsupportal
    {
        View = 2951,

        Operate = 2952,

        Restricted = 2953,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Emailorchestratordeveloper.SUPTL.Communications
{
    public enum Email
    {
        View = 2958,

        AddEdit = 2959,

        Send = 2960,
    }

    public enum Settings
    {
        AddEdit = 2961,
    }

    public enum Recipients
    {
        View = 2962,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Export.TCSPM.Export
{
    public enum Export
    {
        View = 2965,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Settings.TCSPM.Contributions
{
    public enum Contributions
    {
        Manage = 2968,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.RTRSupportal.SUPTL.RTRRetro
{
    public enum RTRRetro
    {
        View = 2969,

        Operate = 2970,

        Restricted = 2971,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Legacypermissions.LPT.Legacypermissions
{
    public enum Test
    {
        View = 2972,

        Manage = 2973,
    }
}

namespace Company.Permissions.Resolver.PermissionFlags.Global.User
{
    public enum Administrator
    {
        CompanyEmployee = 1,

        LegalEntity = 2,

        Environment = 3,
    }
}
