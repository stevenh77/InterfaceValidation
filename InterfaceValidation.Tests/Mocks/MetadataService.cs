using System.Collections.Generic;
using InterfaceValidation.Core;

namespace InterfaceValidation.Tests.Mocks
{
    public class MetadataService : IMetadataService
    {
        public Metadata Get()
        {
            return new Metadata()
            {
                Path = @"c:\",
                Files = new List<File>()
                {
                    new File("client", true)
                    {
                        Columns = new List<Column>()
                        {
                            new Column("FullName", true, "string"),
                            new Column("DateOfBirth", false, "dateTime"),
                            new Column("CashInPocket", true, "decimal"),
                            new Column("NickName", true, "string")
                        }
                    },
                    new File("address", true)
                    {
                        Columns = new List<Column>()
                        {
                            new Column("Line1", true, "string"),
                            new Column("Town", false, "string"),
                            new Column("Country", true, "enum")
                        }
                    },
                    new File("Accounts", true),
                    new File("AccTransactions", false)
                    {
                        Columns = new List<Column>()
                        {
                            new Column("Amount", true, "decimal")
                        }
                    }
                }
            };
        }
    }
}
