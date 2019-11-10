using Motorcycle.DATA.Model;
using System.Collections.Generic;

namespace Motorcycle.DATA.Repositories
{
    public class MotorCycleRepository : IRepository<MotorCycle>
    {
        public static List<MotorCycle> motorCycles = new List<MotorCycle> {
            new MotorCycle{ Id=1,Model="Honda - CBR 1000 RR",IsAutomatic=false,Year=2019 },
            new MotorCycle{ Id=2,Model="Honda - CBR 500 R",IsAutomatic=false,Year=2019 },
            new MotorCycle{ Id=3,Model="Yamaha - Xmax - 250",IsAutomatic=true,Year=2019 },
            new MotorCycle{ Id=4,Model="Yamaha - R25",IsAutomatic=false,Year=2019 }
        };
        public bool Add(MotorCycle motorCycle)
        {
            if (motorCycle == null)
                return false;

            motorCycles.Add(motorCycle);

            return true;
        }

        public bool Delete(int id)
        {
            if (id <= 0)
                return false;

            var motorCycle = GetById(id);

            if (motorCycle == null)
                return false;

            return motorCycles.Remove(motorCycle);
        }

        public IEnumerable<MotorCycle> Get()
        {
            return motorCycles;
        }

        public MotorCycle GetById(int id)
        {
            if (id <= 0)
                return null;

            var motorCycle = motorCycles.Find(x => x.Id == id);

            return motorCycle;
        }

        public MotorCycle Update(MotorCycle motorCycle, int id)
        {
            if (motorCycle == null || id <= 0)
                return null;

            var oldMotorCyle = GetById(id);
            if (oldMotorCyle == null)
                return null;

            oldMotorCyle.Id = motorCycle.Id > 0 ? motorCycle.Id : oldMotorCyle.Id;
            oldMotorCyle.Model = motorCycle.Model;
            oldMotorCyle.IsAutomatic = motorCycle.IsAutomatic;
            oldMotorCyle.Year = motorCycle.Year;

            return oldMotorCyle;
        }
    }
}
