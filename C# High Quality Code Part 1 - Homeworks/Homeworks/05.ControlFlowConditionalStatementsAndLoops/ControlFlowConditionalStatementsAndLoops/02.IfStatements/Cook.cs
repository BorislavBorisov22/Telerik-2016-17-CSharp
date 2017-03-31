namespace IfStatements
{
    public class Cook
    {
        public void CookPotato()
        {
            Potato potato = new Potato();

            if (potato == null)
            {
                return;
            }

            if (!(potato.HasBeenPeeled || potato.IsRotten))
            {
                this.CookPotato(potato);
            }

        }

        private void CookPotato(Potato potato)
        {

        }
    }
}
