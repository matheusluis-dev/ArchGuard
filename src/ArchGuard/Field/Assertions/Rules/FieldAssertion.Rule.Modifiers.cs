namespace ArchGuard
{
    public sealed partial class FieldAssertion
    {
        public IFieldAssertionSequence BeStatic()
        {
            _context.AddPredicate(FieldPredicate.Static);
            return this;
        }

        public IFieldAssertionSequence NotBeStatic()
        {
            _context.AddPredicate(FieldPredicate.NotStatic);
            return this;
        }

        public IFieldAssertionSequence BeConst()
        {
            _context.AddPredicate(FieldPredicate.Const);
            return this;
        }

        public IFieldAssertionSequence NotBeConst()
        {
            _context.AddPredicate(FieldPredicate.NotConst);
            return this;
        }

        public IFieldAssertionSequence BeReadonly()
        {
            _context.AddPredicate(FieldPredicate.Readonly);
            return this;
        }

        public IFieldAssertionSequence NotBeReadonly()
        {
            _context.AddPredicate(FieldPredicate.NotReadonly);
            return this;
        }
    }
}
