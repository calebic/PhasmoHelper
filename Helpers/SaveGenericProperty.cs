using System;
using Newtonsoft.Json;

namespace Phasmophobia_Save_Editor
{
    // Token: 0x02000007 RID: 7
    public class SaveGenericProperty
    {
        // Token: 0x17000001 RID: 1
        // (get) Token: 0x06000014 RID: 20 RVA: 0x00005100 File Offset: 0x00003300
        // (set) Token: 0x06000015 RID: 21 RVA: 0x00005108 File Offset: 0x00003308
        [JsonProperty("__type")]
        public string Type { get; set; }

        // Token: 0x17000002 RID: 2
        // (get) Token: 0x06000016 RID: 22 RVA: 0x00005111 File Offset: 0x00003311
        // (set) Token: 0x06000017 RID: 23 RVA: 0x00005119 File Offset: 0x00003319
        [JsonProperty("value")]
        public object Value { get; set; }
    }
}
