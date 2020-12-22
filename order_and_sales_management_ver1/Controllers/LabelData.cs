using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using order_and_sales_management_ver1.Models;


namespace order_and_sales_management_ver1.Controllers
{
    public class LabelData
    {
        public string typeOfPrintMedia { get; set; }
        public List<string> headerLines { get; set; }
        public List<string> detailLines { get; set; }
        public List<string> footerLines { get; set; }
        public string barcode { get; set; }
        public int numberOfCopies { get; set; }
        public int typeOfLabel { get; set; }

        public string setLabelData(LabelModel label)
        {
            LabelData labelData = new LabelData();
            labelData.headerLines = new List<string>();
            labelData.detailLines = new List<string>();
            labelData.typeOfPrintMedia = "Label";
            labelData.headerLines.Add(label.productName);
            labelData.headerLines.Add(label.productAmount);
            labelData.detailLines.Add(label.productContents);
            labelData.detailLines.Add(label.productLawStr);
            labelData.detailLines.Add(label.productStoringCond);
            labelData.detailLines.Add(label.alerji);
            labelData.detailLines.Add(label.productLotNo);
            labelData.detailLines.Add("IMALAT TARİHİ: " + DateTime.Now.ToString("dd-MM-yyyy"));
            labelData.detailLines.Add(label.productShelfLife);
            labelData.footerLines.Add(label.companyInfo);
            if ((label.companyInfo != null) && label.companyInfo.Length > 0)
                labelData.typeOfLabel = 1;
            else
                labelData.typeOfLabel = 0;
            labelData.detailLines.Add(label.mensei);
            labelData.barcode = label.productBarcodeID;
            labelData.numberOfCopies = label.numberOfCopies;
            String jsonOutput = JsonConvert.SerializeObject(labelData, Formatting.Indented);
            return (jsonOutput);
        }

        public void sendToPrintServer(LabelModel label)
        {
            LabelData labelData = new LabelData();
            string labelStr = labelData.setLabelData(label);

        }

    }
}
