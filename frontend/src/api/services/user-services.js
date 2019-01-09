export const getByUsername = (username, callback) => {
  fetch('http://localhost:4200/api/users/'+username, {method: 'GET'})
  .then(response => response.json())
  .then(response => callback(response))
  .catch(err => callback(err));
} 