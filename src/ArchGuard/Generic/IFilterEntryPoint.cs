namespace ArchGuard.Generic;

public interface IFilterEntryPoint<TRule>
{
    TRule That { get; }
}
