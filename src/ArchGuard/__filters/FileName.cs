namespace ArchGuard.__filters;

using System.Linq;
using ArchGuard.__filters.Engines;
using ArchGuard.Core.Contexts;
using ArchGuard.Core.Type.Models;
using ArchGuard.Filters.Base;
using ArchGuard.Filters.Types;

internal class FileName
{
    internal void A()
    {
        var filterContext = new TypeFilterContext(Enumerable.Empty<TypeDefinition>());

        var entry = new GuardEngine<TypesRules, TypeDefinition>(new TypesRules(), filterContext);

        var start = entry.Start();

        start.That.AreClasses().And(types => types.ArePublic().Or.AreInternal()).And.AreSealed();
    }
}
