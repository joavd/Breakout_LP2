using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameEngine {
    /// <summary>
    /// Class for all game objects
    /// </summary>
    public class GameObject : IGameObject, IEnumerable<Component> {
        /// <summary>
        /// Scene where the game object is
        /// </summary>
        public Scene ParentScene { get; internal set; }

        /// <summary>
        /// The name of this game object
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Is this object renderable?
        /// </summary>
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

        /// <summary>
        /// Create a new game object
        /// </summary>
        /// <param name="name">Name of the game object</param>
        public GameObject(string name) {
            Name = name;
            components = new List<Component>();
        }

        /// <summary>
        /// Add a component to this game object
        /// </summary>
        /// <param name="component">Component to add</param>
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

        /// <summary>
        /// Get component of type
        /// </summary>
        /// <typeparam name="T">Type of the component</typeparam>
        /// <returns></returns>
        public T GetComponent<T>() where T : Component {
            return components.FirstOrDefault(component => component is T) as T;
        }

        /// <summary>
        /// Get component of type
        /// </summary>
        /// <param name="type">Type of the component</param>
        /// <returns></returns>
        public Component GetComponent(Type type) {
            return components.FirstOrDefault(
                component => type.IsInstanceOfType(component));
        }

        /// <summary>
        /// Get component of type
        /// </summary>
        /// <typeparam name="T">Type of the component</typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetComponents<T>() where T : Component {
            return components
                .Where(component => component is T)
                .Select(component => component as T);
        }

        /// <summary>
        /// Initialize all components in this game object
        /// </summary>
        public void Start() {
            foreach (Component component in components) {
                component.Start();
            }
        }

        /// <summary>
        /// Update all components in this game object
        /// </summary>
        public void Update() {
            foreach (Component component in components) {
                component.Update();
            }
        }

        /// <summary>
        /// Tear fown all components in this game object
        /// </summary>
        public void Finish() {
            foreach (Component component in components) {
                component.Finish();
            }
        }

        // The methods below are required for implementing the IEnumerable<T>
        // interface

        /// <summary>
        /// Go through all components in this game object
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Component> GetEnumerator() {
            return components.GetEnumerator();
        }

        // Required for IEnumerable<T> implementation
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
