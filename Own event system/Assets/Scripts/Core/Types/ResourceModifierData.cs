namespace MyGame.Core.Types
{
    public struct ResourceModifierData
    {
        public ResourceType Resource;
        public int Amount;
        public ResourceModifierData(ResourceType resource, int amount)
        {
            Resource = resource;
            Amount = amount;
        }
    }
}
