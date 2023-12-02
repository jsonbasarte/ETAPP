import axios from "axios";

const httpHelper = axios.create({
//   baseURL: window.location.hostname + '/api',
  timeout: 60000,
  // headers: {'X-Custom-Header': 'foobar'}
});

export default httpHelper;
