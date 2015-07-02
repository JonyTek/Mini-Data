﻿namespace MiniData.Core.Model
{
    public abstract class AbstractWhere<T>
    {
        protected AbstractWhere(){}

        protected AbstractWhere(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        internal abstract WhereType Type { get; }
    }
}