using System.Reflection.Emit;

namespace MyOpCodeTable.Shared
{
    public class OpCode
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public sbyte Size { get; set; }
        public string Info { get; set; }
        public OpCodeType OpCodeType { get; set; }
        public FlowControl FlowControl { get; set; }
        public OperandType OperandType { get; set; }
        public string StackBehaviourPush { get; set; }
        public string StackBehaviourPop { get; set; }
    }
}
