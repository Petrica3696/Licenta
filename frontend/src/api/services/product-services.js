export const getProducts = (callback) => {
  fetch('http://localhost:4200/api/products', {method: 'GET'})
  .then(response => response.json())
  .then(response => callback(response))
  .catch(err => callback(err));
}  

export const getProductById = (id, callback) => {
  fetch('http://localhost:4200/api/products/'+id, {method: 'GET'})
  .then(response => response.json())
  .then(response => callback(response))
  .catch(err => callback(err));
}  
