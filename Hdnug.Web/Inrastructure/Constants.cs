namespace Hdnug.Web.Inrastructure
{
    public static class Constants
    {
        public const string SiteUploadDir = "~/Content/Images/Site";
        public const string SpeakerUploadDir = "~/Content/Images/Speakers";
        public const string SponsorUploadDir = "~/Content/Images/Sponsors";

        public static readonly string[] ValidImageTypes =
        {
            "image/gif",
            "image/jpeg",
            "image/pjpeg",
            "image/png"
        };
    }
}