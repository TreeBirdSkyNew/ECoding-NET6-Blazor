

namespace E_CODING_FrontBlazor.DTOs
{
    public class Root
    {
        public string text { get; set; }
        public string value { get; set; }
        public List<Child> children { get; set; }
        public bool? collapsed { get; set; }
    }
}
