using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    [Keyless]
    public class Statics
    {
        public int Providers { get; set; }

        public int Jobs { get; set; }
        public int Customer { get; set; }

    }
}
