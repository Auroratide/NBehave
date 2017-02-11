﻿using System.Collections.Generic;
using System.Linq;

namespace Auroratide.NBehave.Internal {
	public class ContainsMatcher<T> : Matcher {
		private T obj;

		public ContainsMatcher(T obj) {
			this.obj = obj;
		}

		public bool Matches(object collection) {
            return ((IEnumerable<T>)collection).Contains(obj);
		}

		public bool Equals(Matcher other) {
            return this.obj.Equals(((ContainsMatcher<T>)other).obj);
		}

		override public int GetHashCode() {
			return obj.GetHashCode();
		}
	}
}
