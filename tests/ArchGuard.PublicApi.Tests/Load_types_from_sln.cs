namespace ArchGuard.PublicApi.Tests
{
    public sealed class Load_types_from_sln
    {
        [Fact]
        public void Successfully_load_types_from_given_sln()
        {
            // Arrange
            var searchParameters = new SolutionSearchParameters
            {
                SlnPath = "ArchGuard.sln",
                Preprocessor = "net9_0",
                ProjectName = "ArchGuard.MockedAssembly.Classes",
            };

            // Act
            var types = Types.InSolution(searchParameters).GetTypes();

            // Assert
            Check.That(types).HasFirstElement();
        }

        [Fact]
        public void Error_when_sln_does_not_exists()
        {
            // TODO: create specific exception

            // Arrange
            var searchParameters = new SolutionSearchParameters
            {
                SlnPath = $"C:/{Guid.NewGuid()}",
                Preprocessor = "net9_0",
                ProjectName = "It.Does.Not.Exists",
            };

            // Act
            Action @action = () => Types.InSolution(searchParameters).GetTypes();

            // Assert
            Check.ThatCode(@action).ThrowsAny();
        }

        [Fact]
        public void Error_when_project_name_is_invalid()
        {
            // TODO: create specific exception

            // Arrange
            var searchParameters = new SolutionSearchParameters
            {
                SlnPath = "ArchGuard.sln",
                Preprocessor = "net9_0",
                ProjectName = "It.Does.Not.Exists",
            };

            // Act
            Action @action = () => Types.InSolution(searchParameters).GetTypes();

            // Assert
            Check.ThatCode(@action).ThrowsAny();
        }
    }
}
