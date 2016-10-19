namespace MeterReadingMobile.WebApi.Intrata.Model
{
    public class InstallationBase : ModelBase
    {
        public string kod { get; set; }
        public string nazwa { get; set; }

        public InstallationBase()
        {

        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public static InstallationBase NewRecord()
        {
            InstallationBase ret = new InstallationBase()
            {
                id = -1
            };
            return ret;
        }
    }
}
