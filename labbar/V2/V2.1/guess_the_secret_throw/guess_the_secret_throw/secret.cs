using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace guess_the_secret_throw
{
    public class secret
    {
        public int _faceValue;

        public int Throw()
        {
            Random mRandom = new Random();
            _faceValue = mRandom.Next(1, 7);

            return _faceValue;
        }
    }
}
