namespace MyOrangeCMS_RazorVersion.Service
{
    public class LeftMenuService
    {
        public List<string> GetMenuList()
        {
            return new List<string>
            {
                "top",
                "left"
            };
        }
    }
}
