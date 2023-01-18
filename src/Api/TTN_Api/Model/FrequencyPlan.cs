using System;
using System.Collections.Generic;

#nullable disable

namespace TTN_DDOI.Model
{
    public partial class FrequencyPlan
    {
        public FrequencyPlan()
        {
            Devices = new HashSet<Device>();
        }

        public int Id { get; set; }
        public string FrequencyId { get; set; }
        public string FrequencyName { get; set; }
        public int? FrequencyBase { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}
