namespace F10
{
    using System;

    public class Try<S> : Try<S, Error>
    {
        public Try(S value)
            : base(value){}

        public Try(Error error)
            : base(error) { }

        public static implicit operator Try<S>(S value) => new Try<S>(value);
        public static implicit operator Try<S>(Error value) => new Try<S>(value);

        public override bool Equals(object obj)
        {
            if(obj is Try<S>)
            {
                var tryOther = (Try<S>) obj;

                if(this.IsSuccess && tryOther.IsSuccess)
                {
                    return this.Success.Equals(tryOther.Success);
                }else if(this.IsFailed && tryOther.IsFailed)
                {
                    return this.Failed.Equals(tryOther.Failed);
                }
                
            }

            return false;
        }

        public override int GetHashCode()
        {
            if (IsSuccess) return this.Success.GetHashCode();
            else return this.Failed.GetHashCode();
        }
    }
}
