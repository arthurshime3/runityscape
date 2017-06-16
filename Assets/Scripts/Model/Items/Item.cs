﻿using Scripts.Model.Spells;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Model.Items {

    public abstract class Item {
        public static readonly HashSet<Flag> STANDARD_FLAGS = new HashSet<Flag>() { Flag.SELLABLE, Flag.TRASHABLE };

        public readonly string Name;
        public readonly Sprite Icon;
        public readonly string Flavor;
        public readonly TargetType Target;
        public readonly int BasePrice;

        protected readonly HashSet<Flag> flags;

        public Item(Sprite icon, int basePrice, TargetType target, string name, string description) {
            this.flags = new HashSet<Flag>();
            foreach (Flag f in STANDARD_FLAGS) {
                flags.Add(f);
            }
            this.BasePrice = basePrice;
            this.Target = target;
            this.Name = name;
            this.Icon = icon;
            this.Flavor = description;
        }

        public bool HasFlag(Flag f) {
            return flags.Contains(f);
        }

        public string Description {
            get {
                string other = DescriptionHelper;
                string flavor = string.Empty;
                if (string.IsNullOrEmpty(other)) {
                    flavor = string.Format("{0}", Flavor);
                } else {
                    flavor = string.Format(flavor);
                }
                return string.Format("{0}{1}", other, flavor);
            }
        }

        protected abstract string DescriptionHelper {
            get;
        }

        public bool IsUsable(SpellParams caster, SpellParams target) {
            return true; // currentCount > 0 && IsMeetOtherRequirements(caster, target);
        }

        public override bool Equals(object obj) {
            return GetType().Equals(obj.GetType());
        }

        public override int GetHashCode() {
            return Name.GetHashCode() ^ Description.GetHashCode();
        }

        protected abstract bool IsMeetOtherRequirements(SpellParams caster, SpellParams target);


    }
}