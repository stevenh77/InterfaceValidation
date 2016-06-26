using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;

namespace InterfaceValidation.Tests.Mocks
{
    class FileSystem
    {
        public MockFileSystem Get()
        {
            return new MockFileSystem(new Dictionary<string, MockFileData>
            {
                {@"c:\client.txt", new MockFileData("fullName|haircolour|cashInPocket|dateOfBirth")},
                {@"c:\Transactions.txt", new MockFileData("blah")}
            });
        }
    }
}
