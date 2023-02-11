using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class Inventory : MonoBehaviour
    {
        private List<string> _docs;

        private void Start()
        {
            _docs = new List<string>();
        }
        public void AddDocs(string documentsNumber) => _docs.Add(documentsNumber);

        private void Update()
        {
            Debug.Log(_docs.Count);
        }

    }
}
