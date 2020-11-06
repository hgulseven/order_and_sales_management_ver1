using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace order_and_sales_management_ver1.Models
{
    [NotMapped]
    public partial class Invoice
    {
        public class InvoiceLine
        {
            public string orderID { get; set; }                                         /* order id of the invoice line */
            public DateTime orderDate { get; set; }                             /* date of the order for the invoice line*/
            public int lineID { get; set; }                                                 /* invoice line id*/
            [Display(Name = "Miktar")]
            public decimal invoicedQuantity { get; set; }                   /* quantity of item*/
            [Display(Name = "Birim Fiyatı")]
            [BindRequired]
            public decimal itemPrice { get; set; }                                  /* price of the item before discount */
            public decimal taxableAmount { get; set; }                       /*amount before tax    */
            public decimal taxAmount { get; set; }                              /* tax amount for the it em */
            [Display(Name = "Ürün Adı")]

            public string itemName { get; set; }                                     /* name of the item */
            [Display(Name = "Satıcı Kodu")]
            [BindRequired]
            public string sellersIDForItem { get; set; }                        /* sellers identification number for the item */
            [Display(Name = "Ürün Açıklaması")]
            public string itemDesc { get; set; }                                     /* name of the item */
            [Display(Name = "Gülseven Ürün Kodu")]
            [BindRequired]
            public string urunKodu { get; set; }

        }

            [Display(Name = "Teadrikçi")]
            [BindRequired]
            public string suplier{ get; set; }

            [Display(Name = "Alıcı Vergi Kimlik no")]
            public string partyId { get; set; }                                                 /* VKN of the customer */
            [Display(Name = "Alıcı Vergi Dairesi")]
            public string taxSchemeName { get; set; }                                 /* Tax office name */
            [Display(Name = "İnidirim Oranı")]

            public decimal allowanceMultiplier { get; set; }                      /* Discount percentage */
            [Display(Name = "İndirim Tutarı")]

            public decimal allowanceAmount { get; set; }                          /*discount amount */
            public decimal taxAmount { get; set; }                                         /* tax amount */
            public decimal taxPercentage { get; set; }                                     /* tac percentage */

            public decimal amountBeforeTax { get; set; }                           /* amount for tax calculation */
            [NotMapped]

            public List<InvoiceLine> invoiceLines { get; set; }                    /* items on the invoice */

        public Invoice()
        {
            /*this.invc= new InvoiceData();*/
            invoiceLines = new List<InvoiceLine>();
        }
        public static string CONST_TAXID = "4210041031";
        public static string CONST_TAXOFFICE = "ALİ FUAT CEBESOY VERGİ DAİRESİ";

        public void fillToStructure(XMLKeyValuePairs xmlKeyValuePairs)
        {
            int i;
            string attrib = "";

            InvoiceLine invoiceLine;

            partyId = xmlKeyValuePairs.getInvoiceValueForKey("AccountingCustomerParty.Party.PartyIdentification.ID", attrib);
            taxSchemeName = xmlKeyValuePairs.getInvoiceValueForKey("AccountingCustomerParty.Party.PartyTaxScheme.TaxScheme.Name", attrib);
            if (partyId == CONST_TAXID)
            {
                suplier = xmlKeyValuePairs.getInvoiceValueForKey("AccountingSupplierParty.Party.PartyName.Name", attrib);
                try
                {
                    allowanceMultiplier = decimal.Parse(xmlKeyValuePairs.getInvoiceValueForKey("AllowanceCharge.MultiplierFactorNumeric", attrib).Replace('.', ','));
                    allowanceAmount = decimal.Parse(xmlKeyValuePairs.getInvoiceValueForKey("AllowanceCharge.Amount", attrib).Replace('.', ','));
                } catch (Exception ex)
                {
                    allowanceMultiplier = 0;
                    allowanceAmount = 0;
                }
                taxAmount = decimal.Parse(xmlKeyValuePairs.getInvoiceValueForKey("TaxTotal.TaxAmount", attrib).Replace('.', ','));
                taxPercentage = decimal.Parse(xmlKeyValuePairs.getInvoiceValueForKey("TaxTotal.TaxSubtotal.Percent", attrib).Replace('.',','));
                amountBeforeTax = decimal.Parse(xmlKeyValuePairs.getInvoiceValueForKey("TaxTotal.TaxSubtotal.TaxableAmount", attrib).Replace('.', ','));
                int numberOfInvoiceLines = xmlKeyValuePairs.getLineCountOfInvoice();
                for (i = 0; i < numberOfInvoiceLines; i++)
                {
                    invoiceLine = new InvoiceLine();
                    try
                    {
                        invoiceLine.orderID = xmlKeyValuePairs.getInvoiceLineValueForKey("InvoiceLine.Note.OrderLineReference.OrderReference.SalesOrderID", i, attrib);
                        invoiceLine.orderDate = DateTime.Parse(xmlKeyValuePairs.getInvoiceLineValueForKey("InvoiceLine.Note.OrderLineReference.OrderReference.IssueDate", i, attrib));
                    } catch (Exception ex)
                    {
                        invoiceLine.orderID = "0";
                        invoiceLine.orderDate = DateTime.Today;
                    }
                    invoiceLine.lineID = int.Parse(xmlKeyValuePairs.getInvoiceLineValueForKey("InvoiceLine.ID", i, attrib));
                    invoiceLine.invoicedQuantity = decimal.Parse(xmlKeyValuePairs.getInvoiceLineValueForKey("InvoiceLine.InvoicedQuantity", i, attrib).Replace('.', ','));
                    invoiceLine.itemPrice = decimal.Parse(xmlKeyValuePairs.getInvoiceLineValueForKey("InvoiceLine.Price.PriceAmount", i, attrib).Replace('.', ','));
                    try
                    {
                        invoiceLine.taxableAmount = decimal.Parse(xmlKeyValuePairs.getInvoiceLineValueForKey("InvoiceLine.TaxTotal.TaxSubtotal.TaxableAmount", i, attrib).Replace('.', ','));
                        invoiceLine.taxAmount = decimal.Parse(xmlKeyValuePairs.getInvoiceLineValueForKey("InvoiceLine.TaxTotal.TaxSubtotal.TaxAmount", i, attrib).Replace('.', ','));
                    } catch (Exception ex)
                    {
                        invoiceLine.taxAmount = 0;
                        invoiceLine.taxableAmount = 0;
                    }
                    invoiceLine.itemName = xmlKeyValuePairs.getInvoiceLineValueForKey("InvoiceLine.Item.Name", i, attrib);
                    invoiceLine.itemDesc = xmlKeyValuePairs.getInvoiceLineValueForKey("InvoiceLine.Item.Description", i, attrib);
                    invoiceLine.sellersIDForItem = xmlKeyValuePairs.getInvoiceLineValueForKey("InvoiceLine.Item.SellersItemIdentification.ID", i, attrib);
                    invoiceLines.Add(invoiceLine);
                }

            }
        }


    }
    public class XMLKeyValuePairs
    {
        public class Attrib
        {
            public string key { get; set; }
            public string value { get; set; }
        }

        public class KeyValuePairs
        {
            public string key { get; set; }
            public string value { get; set; }
            public List<Attrib> attribs { get; set; }
        }

        public List<KeyValuePairs> basicInvoiceKeyValePairs;
        public List<List<KeyValuePairs>> invoiceLinesKeyValuePairs;
        private object basicInvoiceKeyValuePairs;

        public XMLKeyValuePairs()
        {
            basicInvoiceKeyValePairs = new List<KeyValuePairs>();
            invoiceLinesKeyValuePairs = new List<List<KeyValuePairs>>();
        }
        private string removePrefix(string str)
        {
            int startPos = 0;
            int numberOfChars = 0;

            startPos = str.IndexOf(':', 0) + 1;
            numberOfChars = str.Length - startPos;
            return (str.Substring(startPos, numberOfChars));
        }

        public int getLineCountOfInvoice()
        {
            return this.invoiceLinesKeyValuePairs.Count;
        }
        public string getInvoiceValueForKey(string key, string atrib)
        {
            string value = "";
            int i;

            foreach (KeyValuePairs pair in this.basicInvoiceKeyValePairs)
            {
                if (pair.key == key)
                {
                    value = pair.value;
                    break;
                }
            }
            return value;
        }

        public string getInvoiceLineValueForKey(string key, int lineID, string attrib)
        {
            string value = "";
            int i;
            List<KeyValuePairs> line;
            if (lineID < this.invoiceLinesKeyValuePairs.Count)
            {
                line = invoiceLinesKeyValuePairs.ElementAt(lineID);
                foreach (KeyValuePairs pair in line)
                {
                    if (pair.key == key)
                    {
                        value = pair.value;
                        break;
                    }
                }
            }
            return value;
        }

        private XmlNode iterator(XmlNode nodes, string nodeName, List<KeyValuePairs> keyValue)
        {
            int i;
            XmlNode leafNode = null;
            int startPos;
            int numberOfChars;
            string tempNodeName="";

            startPos = nodes.Name.IndexOf(':', 0) + 1;
            numberOfChars = nodes.Name.Length - nodes.Name.IndexOf(':', 0) - 1;
            if (nodeName == "")
            {
                nodeName = nodes.Name.Substring(startPos, numberOfChars);
            }
            else
            {
                nodeName = nodeName + "." + nodes.Name.Substring(startPos, numberOfChars);
            }
            Console.WriteLine(nodes.Name);
            foreach (XmlNode node in nodes.ChildNodes)
            {
                i = 0;
                leafNode = node;
                if (leafNode.NodeType != XmlNodeType.Text && leafNode.ChildNodes.Count > 0)
                {
                    while (i < leafNode.ChildNodes.Count)
                    {
                        leafNode = iterator(leafNode, nodeName, keyValue);
                        i++;
                    }
                    if (leafNode.NodeType != XmlNodeType.Text)
                    {

                        nodeName = nodeName + "." + removePrefix(leafNode.Name);
                        Console.WriteLine(leafNode.Name);
                    }
                }
                else
                {
                    /* last leaf should be text if leaf is not empty. İf leaf is empty then normal flow does not occur. hence nodename reinitilaized below by using temp variable */
                    if (leafNode.NodeType != XmlNodeType.Text && leafNode.ChildNodes.Count == 0)
                    {
                        tempNodeName = nodeName;
                        nodeName = nodeName + "." + removePrefix(leafNode.Name);
                    }
                    KeyValuePairs item = new KeyValuePairs();
                    item.key = nodeName;
                    item.value = leafNode.InnerText;
                    item.attribs = new List<Attrib>();
                    foreach (XmlAttribute attr in leafNode.ParentNode.Attributes)
                    {
                        Attrib attrib = new Attrib();
                        attrib.key = attr.Name;
                        attrib.value = attr.Value;
                        item.attribs.Add(attrib);
                    }
                    keyValue.Add(item);
                    Console.WriteLine(nodeName + "    :   " + leafNode.InnerText);
                    if (leafNode.NodeType != XmlNodeType.Text && leafNode.ChildNodes.Count == 0)
                    {
                        nodeName = tempNodeName;
                    }
                }
            }
            return (leafNode);
        }

        public void parseXML(StreamReader file)
        {
            System.Xml.XmlDocument xmlData = new XmlDocument();


            xmlData.Load(file);
            XmlElement root = xmlData.DocumentElement;
            XmlNode lastNode;

            foreach (XmlNode node in root.ChildNodes)
            {
                switch (node.Name)
                {
                    case "cac:AccountingSupplierParty":
                        lastNode = iterator(node, "", basicInvoiceKeyValePairs);
                        break;
                    case "cac:AccountingCustomerParty":
                        lastNode = iterator(node, "", basicInvoiceKeyValePairs);
                        break;
                    case "cac:AllowanceCharge":
                        lastNode = iterator(node, "", basicInvoiceKeyValePairs);
                        break;
                    case "cac:TaxTotal":
                        lastNode = iterator(node, "", basicInvoiceKeyValePairs);
                        break;
                    case "cac:InvoiceLine":
                        List<KeyValuePairs> line = new List<KeyValuePairs>();
                        lastNode = iterator(node, "", line);
                        invoiceLinesKeyValuePairs.Add(line);
                        break;
                }
            }
        }
    }
}
