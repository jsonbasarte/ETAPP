import axios from "axios";

const httpHelper = axios.create({
  baseURL: '/api',
  // headers: {'X-Custom-Header': 'foobar'}
});

export default httpHelper;
