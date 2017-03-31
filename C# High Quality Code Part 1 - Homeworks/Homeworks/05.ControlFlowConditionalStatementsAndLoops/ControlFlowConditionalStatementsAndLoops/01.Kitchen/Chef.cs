namespace ControlFlowConditionalStatementsAndLoops
{
    using System;

    public class Chef
    {
        public void Cook()
        {
            Bowl bowl = GetBowl();

            Potato potato = GetPotato();
            this.Peel(potato);
            this.Cut(potato);
            bowl.Add(potato);

            Carrot carrot = GetCarrot();
            this.Peel(carrot);
            this.Cut(carrot);
            bowl.Add(carrot);
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private void Cut(IVegetable vegetable)
        {
            
        }

        private void Peel(IVegetable vegetable)
        {
            throw new NotImplementedException();
        }
    }
}
