using System;
using Xunit;
using static Permission.PermissionMatrix;

namespace Permission.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var expectedKey = "ManageUser";
            var key = Premissions.ManageUser.GetPermissionKey();
            Assert.Equal(expectedKey, key);
        }

        [Fact]
        public async System.Threading.Tasks.Task TestPermissionRepositoryAsync()
        {
            var repo = new PermissionRepository();
            var lst = await repo.GetAll();
            Assert.NotNull(lst);
            Assert.Contains<PermissionEntity>(lst, t => t.Name == "ManageUser");
        }
    }
}
