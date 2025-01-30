namespace ArchGuard.MockedAssembly.Methods.Asynchronous
{
    public class Class
    {
        public async Task AsyncMethod()
        {
            await Task.FromResult(0);
        }

        public void SyncMethod() { }
    }
}
