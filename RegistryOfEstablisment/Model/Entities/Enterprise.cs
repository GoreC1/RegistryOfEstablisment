﻿namespace RegistryOfEstablisment.Model.Entities
{
    public class Enterprise : BaseEntity
    {
        public EnterpriseType Type { get; set; }
        public ManagementTerritory ManagementTerritory { get; set; }
        public long ITN { get; set; }
        public int Checkpoint { get; set; }
        public string Address { get; set; }
        public string RealAddress { get; set; }
        public string WebSite { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string LegalEntity { get; set; }
    }
}
