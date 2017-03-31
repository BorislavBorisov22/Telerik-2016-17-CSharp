namespace ControlFlowConditionalStatementsAndLoops
{
    public class CellVisitor
    {
        public const int MinX = 0;
        public const int MaxX = 128;
        public const int MinY = 0;
        public const int MaxY = 256;

        private bool shouldVisitCell;

        public CellVisitor()
        {
            this.shouldVisitCell = true;
        }

        public void TryVisitCell(int x, int y)
        {
            bool isXInRange = this.IsCoordinateInRange(x, CellVisitor.MinX, CellVisitor.MaxX);

            bool isYInRange = this.IsCoordinateInRange(y, CellVisitor.MinY, CellVisitor.MaxY);

            if (isXInRange && isYInRange && this.shouldVisitCell)
            {
                this.VisitCell();
            }
        }

        public void VisitCell()
        {

        }

        private bool IsCoordinateInRange(int value, int min, int max)
        {
            return min <= value && value <= max;
        }
    }
}
