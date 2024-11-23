import React, { useState, useEffect } from 'react';

function App() {
  const [searchTerm, setSearchTerm] = useState('');
  const [allSuggestions, setAllSuggestions] = useState([]);
  const [filteredSuggestions, setFilteredSuggestions] = useState([]);
  const [responseData, setResponseData] = useState<any>(null);

  const fetchSuggestions = async () => {
    try {
      const response = await fetch(`https://localhost:7290/api/Students`);
      if (response.ok) {
        const data = await response.json();
        setAllSuggestions(data);
      } else {
        console.error('Error fetching suggestions:', response.statusText);
      }
    } catch (error) {
      console.error('Error fetching suggestions:', error);
    }
  };

  useEffect(() => {
    fetchSuggestions();
  }, []);

  const handleInputChange = (event) => {
    const value = event.target.value;
    setSearchTerm(value);

    if (value && value.length > 1) {
      const lowercasedValue = value.toLowerCase();
      const filtered = allSuggestions.filter(
        (suggestion) =>
          suggestion.firstName.toLowerCase().includes(lowercasedValue) ||
          suggestion.lastName.toLowerCase().includes(lowercasedValue) ||
          suggestion.class.toLowerCase().includes(lowercasedValue)
      );
      setFilteredSuggestions(filtered);
    } else {
      setFilteredSuggestions([]);
    }
  };

  const handleSuggestionClick = (suggestion) => {
    setSearchTerm(`${suggestion.firstName} ${suggestion.lastName} ${suggestion.class}`);
    setFilteredSuggestions([]); 
  };


  const handleButtonClick = () => {
    console.log('Button clicked!');

  };

  return (
    <div className="bg-dark text-white min-vh-100 min-vw-100 d-flex flex-column">
      <div className="container mt-4">
        <div className="d-flex justify-content-center align-items-center">
          <div className="position-relative w-50">
            <input
              type="text"
              className="form-control"
              placeholder="Search..."
              value={searchTerm}
              onChange={handleInputChange}
            />
          </div>
  
          <button className="btn btn-primary ms-2" onClick={handleButtonClick}>
            Search
          </button>
        </div>
      </div>

      {filteredSuggestions.length > 0 && (
        <div className="container mt-4">
          <ul className="list-group">
            {filteredSuggestions.map((suggestion, index) => (
              <li
                key={index}
                className="list-group-item list-group-item-action"
                onClick={() => handleSuggestionClick(suggestion)}
              >
                {suggestion.firstName} {suggestion.lastName} {suggestion.class}
              </li>
            ))}
          </ul>
        </div>
      )}

      <div className="container mt-4 flex-grow-1">
        {responseData ? (
          <pre>{JSON.stringify(responseData, null, 2)}</pre>
        ) : (
          <p>No data to display</p>
        )}
      </div>
    </div>
  );
}

export default App;
