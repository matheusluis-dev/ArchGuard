namespace ArchGuard
{
    public sealed partial class FieldFilter
    {
        public IFieldFilterSequence AreStatic()
        {
            _context.AddPredicate(FieldPredicate.Static);
            return this;
        }

        public IFieldFilterSequence AreNotStatic()
        {
            _context.AddPredicate(FieldPredicate.NotStatic);
            return this;
        }

        public IFieldFilterSequence AreConst()
        {
            _context.AddPredicate(FieldPredicate.Const);
            return this;
        }

        public IFieldFilterSequence AreNotConst()
        {
            _context.AddPredicate(FieldPredicate.NotConst);
            return this;
        }

        public IFieldFilterSequence AreReadonly()
        {
            _context.AddPredicate(FieldPredicate.Readonly);
            return this;
        }

        public IFieldFilterSequence AreNotReadonly()
        {
            _context.AddPredicate(FieldPredicate.NotReadonly);
            return this;
        }
    }
}
