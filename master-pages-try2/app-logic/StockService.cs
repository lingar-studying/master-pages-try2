﻿using System;
using master_pages_try2.app_logic;

namespace asp_learning.app_logic
{
    public class StockService
    {

        public static Stock[] CreateMock()
        {
            //https://finance.yahoo.com/quote/SPY/chart/#eyJsYXlvdXQiOnsiaW50ZXJ2YWwiOjEsInBlcmlvZGljaXR5IjoxLCJ0aW1lVW5pdCI6Im1pbnV0ZSIsImNhbmRsZVdpZHRoIjoyLjM2MTUzODQ2MTUzODQ2MTYsImZsaXBwZWQiOmZhbHNlLCJ2b2x1bWVVbmRlcmxheSI6dHJ1ZSwiYWRqIjp0cnVlLCJjcm9zc2hhaXIiOnRydWUsImNoYXJ0VHlwZSI6Im1vdW50YWluIiwiZXh0ZW5kZWQiOmZhbHNlLCJtYXJrZXRTZXNzaW9ucyI6e30sImFnZ3JlZ2F0aW9uVHlwZSI6Im9obGMiLCJjaGFydFNjYWxlIjoibGluZWFyIiwic3R1ZGllcyI6eyLigIx2b2wgdW5kcuKAjCI6eyJ0eXBlIjoidm9sIHVuZHIiLCJpbnB1dHMiOnsiU2VyaWVzIjoic2VyaWVzIiwiaWQiOiLigIx2b2wgdW5kcuKAjCIsImRpc3BsYXkiOiLigIx2b2wgdW5kcuKAjCJ9LCJvdXRwdXRzIjp7IlVwIFZvbHVtZSI6IiMwZGJkNmVlZSIsIkRvd24gVm9sdW1lIjoiI2ZmNTU0N2VlIn0sInBhbmVsIjoiY2hhcnQiLCJwYXJhbWV0ZXJzIjp7ImNoYXJ0TmFtZSI6ImNoYXJ0IiwiZWRpdE1vZGUiOnRydWV9LCJkaXNhYmxlZCI6ZmFsc2V9fSwicGFuZWxzIjp7ImNoYXJ0Ijp7InBlcmNlbnQiOjEsImRpc3BsYXkiOiJTUFkiLCJjaGFydE5hbWUiOiJjaGFydCIsImluZGV4IjowLCJ5QXhpcyI6eyJuYW1lIjoiY2hhcnQiLCJwb3NpdGlvbiI6bnVsbH0sInlheGlzTEhTIjpbXSwieWF4aXNSSFMiOlsiY2hhcnQiLCLigIx2b2wgdW5kcuKAjCJdfX0sInNldFNwYW4iOnsibXVsdGlwbGllciI6MSwiYmFzZSI6InRvZGF5IiwicGVyaW9kaWNpdHkiOnsiaW50ZXJ2YWwiOjEsInBlcmlvZCI6MSwidGltZVVuaXQiOiJtaW51dGUifSwic2hvd0V2ZW50c1F1b3RlIjp0cnVlLCJmb3JjZUxvYWQiOmZhbHNlLCJ1c2VFeGlzdGluZ0RhdGEiOnRydWV9LCJvdXRsaWVycyI6ZmFsc2UsImFuaW1hdGlvbiI6dHJ1ZSwiaGVhZHNVcCI6eyJzdGF0aWMiOnRydWUsImR5bmFtaWMiOmZhbHNlLCJmbG9hdGluZyI6ZmFsc2V9LCJsaW5lV2lkdGgiOjIsImZ1bGxTY3JlZW4iOnRydWUsInN0cmlwZWRCYWNrZ3JvdW5kIjp0cnVlLCJjb2xvciI6IiMwMDgxZjIiLCJzdHVkeUxlZ2VuZCI6eyJleHBhbmRlZCI6dHJ1ZX0sInN5bWJvbHMiOlt7InN5bWJvbCI6IlNQWSIsInN5bWJvbE9iamVjdCI6eyJzeW1ib2wiOiJTUFkiLCJxdW90ZVR5cGUiOiJFVEYiLCJleGNoYW5nZVRpbWVab25lIjoiQW1lcmljYS9OZXdfWW9yayIsInBlcmlvZDEiOjE3MjE2NTMyMDAsInBlcmlvZDIiOjE3MjE4MjYwMDB9LCJwZXJpb2RpY2l0eSI6MSwiaW50ZXJ2YWwiOjEsInRpbWVVbml0IjoibWludXRlIiwic2V0U3BhbiI6eyJtdWx0aXBsaWVyIjoxLCJiYXNlIjoidG9kYXkiLCJwZXJpb2RpY2l0eSI6eyJpbnRlcnZhbCI6MSwicGVyaW9kIjoxLCJ0aW1lVW5pdCI6Im1pbnV0ZSJ9LCJzaG93RXZlbnRzUXVvdGUiOnRydWUsImZvcmNlTG9hZCI6ZmFsc2UsInVzZUV4aXN0aW5nRGF0YSI6dHJ1ZX19XX0sImV2ZW50cyI6eyJkaXZzIjp0cnVlLCJzcGxpdHMiOnRydWUsInRyYWRpbmdIb3Jpem9uIjoibm9uZSIsInNpZ0RldkV2ZW50cyI6W119LCJwcmVmZXJlbmNlcyI6eyJjdXJyZW50UHJpY2VMaW5lIjp0cnVlLCJkaXNwbGF5Q3Jvc3NoYWlyc1dpdGhEcmF3aW5nVG9vbCI6ZmFsc2UsImRyYWdnaW5nIjp7InNlcmllcyI6dHJ1ZSwic3R1ZHkiOmZhbHNlLCJ5YXhpcyI6dHJ1ZX0sImRyYXdpbmdzIjpudWxsLCJoaWdobGlnaHRzUmFkaXVzIjoxMCwiaGlnaGxpZ2h0c1RhcFJhZGl1cyI6MzAsIm1hZ25ldCI6ZmFsc2UsImhvcml6b250YWxDcm9zc2hhaXJGaWVsZCI6bnVsbCwibGFiZWxzIjp0cnVlLCJsYW5ndWFnZSI6bnVsbCwidGltZVpvbmUiOiJBbWVyaWNhL05ld19Zb3JrIiwid2hpdGVzcGFjZSI6NTAsInpvb21JblNwZWVkIjpudWxsLCJ6b29tT3V0U3BlZWQiOm51bGwsInpvb21BdEN1cnJlbnRNb3VzZVBvc2l0aW9uIjpmYWxzZX19 
            //https://finance.yahoo.com/quote/GOOG/
            //https://finance.yahoo.com/quote/T/

            Stock[] stocks = new Stock[3];

            stocks[0] = new Stock("AT&T", "T", 18.21);
            stocks[1] = new Stock("Alphabet", "GOOG", 183.60);
            stocks[2] = new Stock("Tesla", "tsla", 246.38);


            return stocks; 


        }
    }
}
