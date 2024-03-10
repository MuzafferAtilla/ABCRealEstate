import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Product } from '../product';
import { Observable } from 'rxjs';

@Injectable()
export class ProductService {

  constructor(private http:HttpClient) { }

  getProducts():Observable<Product[]>
  {
    return this.http.get<Product[]>("https://localhost:7021/Abc/getProductList")
  }
}
