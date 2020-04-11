using System.Collections.Generic;

namespace WallBuildChecker.Interfaces
{
    public interface IWallDataInput
    {
        public List<BrickSort> GetBricks();
        public WallPattern GetWallPattern();
    }
}