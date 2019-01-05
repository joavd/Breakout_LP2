using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameEngine {

    // Class for all game objects
    public class GameObject : IGameObject, IEnumerable<Component> {

        // Scene where the game object is
        public Scene ParentScene { get; internal set; }

        // The name of this game object
        public string Name { get; }

        // Is this object renderable?
        public bool IsRenderable =>
            containsRenderableComponent && containsPosition;

        // Component which the object can only have one of
        private static readonly Type[] oneOfAKind = new Type[] {
            typeof(Position),
            typeof(KeyObserver),
            typeof(RenderableComponent)
        };

        // Helper variables for the IsRenderable property
        private bool containsRenderableComponent, containsPosition;

        // The components in this game object
        private readonly ICollection<Component> components;

        // Create a new game object
        public GameObject(string name) {
            Name = name;
            components = new List<Component>();
        }

        // Add a component to this game object
        public void AddComponent(Component component) {

            // Check for one of a kind components
            foreach (Type componentType in oneOfAKind) {

                if (componentType.IsInstanceOfType(component) &&
                    GetComponent(componentType) != null) {

                    throw new InvalidOperationException("Game objects can " +
                        "only have one " + componentType.Name + " component");
                }
            }

            // Is this component a position component or 
            // a renderable component?
            if (component is Position) {
                containsPosition = true;
            } else if (component is RenderableComponent) {
                containsRenderableComponent = true;
            }

            // Specify reference to this game object in this component
            component.ParentGameObject = this;

            // Add component to this game object
            components.Add(component);
        }

        // The following methods provide several ways of getting components
        // from this game object
        public T GetComponent<T>() where T : Component {
            return components.FirstOrDefault(component => component is T) as T;
        }

        public Component GetComponent(Type type) {
            return components.FirstOrDefault(
                component => type.IsInstanceOfType(component));
        }

        public IEnumerable<T> GetComponents<T>() where T : Component {
            return components
                .Where(component => component is T)
                .Select(component => component as T);
        }

        // Initialize all components in this game object
        public void Start() {
            foreach (Component component in components) {
                component.Start();
            }
        }

        // Update all components in this game object
        public void Update() {
            foreach (Component component in components) {
                component.Update();
            }
        }

        // Tear fown all components in this game object
        public void Finish() {
            foreach (Component component in components) {
                component.Finish();
            }
        }

        // The methods below are required for implementing the IEnumerable<T>
        // interface

        // Go through all components in this game object
        public IEnumerator<Component> GetEnumerator() {
            return components.GetEnumerator();
        }

        // Required for IEnumerable<T> implementation
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
