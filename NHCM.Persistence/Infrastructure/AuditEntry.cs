using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using NHCM.Domain.Entities;
using NHCM.Persistence.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHCM.Persistence.Infrastructure
{



    public class AuditEntry
    {
       
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
           
        }

        public EntityEntry Entry { get; }
        public string TableName { get; set; }
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();

        public bool HasTemporaryProperties => TemporaryProperties.Any();

        public Audit ToAudit()
        {
            var audit = new Audit();


            audit.OperationTypeId = 1;
            audit.ReocordId = JsonConvert.SerializeObject(KeyValues);   // CHANGE: change the column type of RecordId from long to string to include json
            audit.OperationDate = DateTime.Now;
            audit.DbOjbectName = TableName;
            audit.UserId = 1000; // CHANGE: statement should recieve the id of current user running the operation.

            audit.ValueBefore = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            audit.ValueAfter = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);


            return audit;




            //audit.Columnname = JsonConvert.SerializeObject(KeyValues);
            //audit.Eventdateutc = DateTime.UtcNow;
            //audit.Eventype = 'd';
            //audit.Newvalue = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            //audit.Tbalname = TableName;
            //audit.Recordid = JsonConvert.SerializeObject(KeyValues);
            //audit.Userid = 1;


            //audit.TableName = TableName;

            //audit.KeyValues = JsonConvert.SerializeObject(KeyValues);
            //audit.OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            //audit.NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            //return audit;
        }
    }
}

