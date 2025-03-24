namespace ArchGuard.__filters;

using System.Linq;
using ArchGuard.__filters.Engines;
using ArchGuard.__filters.Types.TypesAssertionRules;
using ArchGuard.Core.Contexts;
using ArchGuard.Core.Type.Models;
using ArchGuard.Filters.Base;
using ArchGuard.Filters.Types;

internal class FileName
{
    internal void A()
    {
        var filterContext = new TypeFilterContext(Enumerable.Empty<TypeDefinition>());

        var entry = new FilterMediator<TypesFilterRules, TypeDefinition>(new(), filterContext);
        var start = entry.Start();

        start.That.AreClasses().And(types => types.ArePublic().Or.AreInternal()).And.AreSealed();
    }

    internal void B()
    {
        var filterContext = new TypeFilterContext(Enumerable.Empty<TypeDefinition>());
        var assertionContext = new AssertionContext<TypeDefinition>(filterContext);

        var entry = new FilterMediator<TypesAssertionRules, TypeDefinition>(new(), assertionContext);
        var start = entry.Start().That;

        start.BeGeneric().And.BeExternallyImmutable();
    }

    internal void C()
    {
        var filterContext = new TypeFilterContext(Enumerable.Empty<TypeDefinition>());
        var assertionContext = new AssertionContext<TypeDefinition>(filterContext);

        var engine = FilterEngine<TypesFilterRules, TypesAssertionRules, TypeDefinition>.Start(
            new(),
            filterContext,
            new(),
            assertionContext
        );

        engine.That.AreClasses().And.AreAbstract().Should.;
    }
}
