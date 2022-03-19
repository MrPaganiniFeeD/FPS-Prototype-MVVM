using System;

namespace ViewModel.Damageble
{
    public interface IDamageableViewModel
    {
        event Action TakingDamage;
    }   
}