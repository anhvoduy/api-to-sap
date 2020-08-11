using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SAP.Middleware.Connector;

namespace NetCoreToSap.Utilities
{
    public class SAPConnectorInterface
    {
        private RfcDestination rfcDestination;

        public bool TestConnection(string destinationName)
        {
            bool result = false;
            try
            {
                rfcDestination = RfcDestinationManager.GetDestination(destinationName);
                if(rfcDestination != null)
                {
                    rfcDestination.Ping();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
                throw new Exception("Connection Failure Error: " + ex.Message);
            }
            return result;
        }

        public DataTable ConvertToDotNetTable(IRfcTable RFCTable)
        {
            DataTable dtTable = new DataTable();

            for (int item = 0; item < RFCTable.ElementCount; item++)
            {
                RfcElementMetadata metadata = RFCTable.GetElementMetadata(item);
                dtTable.Columns.Add(metadata.Name);
            }

            foreach(IRfcStructure row in RFCTable)
            {
                DataRow dr = dtTable.NewRow();
                for(int item=0; item < RFCTable.ElementCount; item++)
                {
                    RfcElementMetadata metadata = RFCTable.GetElementMetadata(item);
                    if(metadata.DataType == RfcDataType.BCD && metadata.Name == "ABC")
                    {
                        dr[item] = row.GetInt(metadata.Name);
                    }
                    else
                    {
                        dr[item] = row.GetString(metadata.Name);
                    }
                    dtTable.Rows.Add(dr);
                }
            }

            return dtTable;
        }

        public DataSet RetrieveCustomers(string country, string destinationName)
        {
            DataSet dsCustomers = new DataSet();
            try
            {
                if (rfcDestination == null)
                {
                    rfcDestination = RfcDestinationManager.GetDestination(destinationName);
                }
                
                RfcRepository rfcRepository = rfcDestination.Repository;
                IRfcFunction rfcFunction = rfcRepository.CreateFunction("RFC_CUSTOMER_DATA");
                rfcFunction.SetValue("COUNTRY", country);
                rfcFunction.Invoke(rfcDestination);
                dsCustomers.Tables.Add(ConvertToDotNetTable(rfcFunction.GetTable("CUSTOMER_INFO")));
            }
            catch(Exception ex)
            {
                throw new Exception("Retrieve Customers Error:" + ex.Message);
            }
            return dsCustomers;
        }

        public DataSet RetrieveCustomerData(string country, string destinationName)
        {
            DataSet dsCustomers = new DataSet();
            try
            {
                if (rfcDestination == null)
                {
                    rfcDestination = RfcDestinationManager.GetDestination(destinationName);
                }

                RfcRepository rfcRepository = rfcDestination.Repository;
                IRfcFunction rfcFunction = rfcRepository.CreateFunction("RFC_CUSTOMER_DATA");
                rfcFunction.SetValue("COUNTRY", country);
                rfcFunction.Invoke(rfcDestination);
                IRfcStructure customerData = rfcFunction.GetStructure("CUSTOMER_DATA");
                IRfcTable CustomerSummary = rfcDestination.Repository.GetTableMetadata("ZIRM_T_CUSTOMER_SUMMARY").CreateTable();
                CustomerSummary = customerData.GetTable("CUSTOMER_DATA");
                dsCustomers.Tables.Add(ConvertToDotNetTable(CustomerSummary));
            }
            catch(Exception ex)
            {
                throw new Exception("Retrieve Customer Data Error:" + ex.Message);
            }
            return dsCustomers;
        }
    }
}
