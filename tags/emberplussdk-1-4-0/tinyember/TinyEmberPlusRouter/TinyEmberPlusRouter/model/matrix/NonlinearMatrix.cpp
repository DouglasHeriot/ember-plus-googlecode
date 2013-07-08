#include "NonlinearMatrix.h"

namespace model { namespace matrix
{
   // overrides

   int NonlinearMatrix::targetCount() const
   {
      return targets().size();
   }

   int NonlinearMatrix::sourceCount() const
   {
      return sources().size();
   }

   Signal* NonlinearMatrix::getTarget(int number) const
   {
      for each(auto signal in targets())
      {
         if(signal->number() == number)
            return signal;
      }

      return nullptr;
   }

   Signal* NonlinearMatrix::getSource(int number) const
   {
      for each(auto signal in sources())
      {
         if(signal->number() == number)
            return signal;
      }

      return nullptr;
   }
}}
