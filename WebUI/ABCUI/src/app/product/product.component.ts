import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Product } from './product';
import { ProductAgeCategory } from './product.age.category';
import { ProductRoomTypeCategory } from './product.room.type.category';
import { ProductSaleTypeCategory } from './product.sale.type.category';
import { ProductSearchPipe } from "./product-search.pipe";
import { FormsModule } from '@angular/forms';
import { ProductService } from './services/product.service';



@Component({
  selector: 'app-product',
  standalone: true,
  templateUrl: './product.component.html',
  styleUrl: './product.component.css',
  imports: [CommonModule, ProductSearchPipe, FormsModule],
  providers: [ProductService]
})
export class ProductComponent implements OnInit {

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.getProducts()
  }
  getProducts() {
    this.productService.getProducts().subscribe(data => {
      this.products = data
      this.productsStage = data
    });
  }
  title = "Ürün Listesi"
  searchText = ""
  minPrice = null
  maxPrice = null
  products: Product[] = []
  productsStage: Product[] = []
  selectedItemsProductAge: string[] = [];
  selectedItemsRoomType: string[] = [];
  selectedItemsSaleType: string[] = [];





  productAgeCategories: ProductAgeCategory[] = [
    { id: 1, value: "Tümü" },
    { id: 2, value: "1" },
    { id: 3, value: "5" },
    { id: 4, value: "10" },
    { id: 5, value: "15" },
    { id: 6, value: "20" }
  ]

  productRoomTypeCategories: ProductRoomTypeCategory[] = [
    { id: 1, value: "Tümü" },
    { id: 2, value: "1+1" },
    { id: 3, value: "2+1" },
    { id: 4, value: "3+1" },
    { id: 5, value: "4+2" },
    { id: 6, value: "5+2" }
  ]

  productSaleTypeCategories: ProductSaleTypeCategory[] = [
    { id: 1, value: "Tümü" },
    { id: 2, value: "Satilik" },
    { id: 3, value: "Kiralik" }
  ]

  maxmin(e: any){
console.log(e,'eee')
  }

  filterChange(value: string, e: any) {
    if (value == "filterAgain") {
      this.products = this.productsStage
      if(this.selectedItemsProductAge.length > 0) {
        this.products = this.products.filter(m => this.selectedItemsProductAge.includes(m.productAge.toString()))
      }
      if(this.selectedItemsRoomType.length > 0) {
        this.products = this.products.filter(m => this.selectedItemsRoomType.includes(m.roomType.toString()))
      }
      if(this.selectedItemsSaleType.length > 0) {
        this.products = this.products.filter(m => this.selectedItemsSaleType.includes(m.saleType.toString()))
      }
    }
    else {
      if (e.target.checked) {
        this.products = this.productsStage
        let item = this.productAgeCategories.find(m => m.value == value)?.value!
        if (item !== null && item !== undefined) {
          this.selectedItemsProductAge.push(item)
          this.products = this.products.filter(m => this.selectedItemsProductAge.includes(m.productAge.toString()))
        }

        item = this.productRoomTypeCategories.find(m => m.value == value)?.value!
        if (item !== null && item !== undefined) {
          this.selectedItemsRoomType.push(item)
          this.products = this.products.filter(m => this.selectedItemsRoomType.includes(m.roomType.toString()))
        }

        item = this.productSaleTypeCategories.find(m => m.value == value)?.value!
        if (item !== null && item !== undefined) {
          this.selectedItemsSaleType.push(item)
          this.products = this.products.filter(m => this.selectedItemsSaleType.includes(m.saleType.toString()))
        }
      }
      if (!e.target.checked) {
        let item = this.productAgeCategories.find(m => m.value == value)?.value!
        if (item !== null && item !== undefined) {
          let index = this.selectedItemsProductAge.indexOf(item)
          if (index > -1) {
            this.selectedItemsProductAge.splice(index, 1);
          }
        }
  
        item = this.productRoomTypeCategories.find(m => m.value == value)?.value!
        if (item !== null && item !== undefined) {
          let index = this.selectedItemsRoomType.indexOf(item)
          if (index > -1) {
            this.selectedItemsRoomType.splice(index, 1);
          }
        }

        item = this.productSaleTypeCategories.find(m => m.value == value)?.value!
        if (item !== null && item !== undefined) {
          let index = this.selectedItemsSaleType.indexOf(item)
          if (index > -1) {
            this.selectedItemsSaleType.splice(index, 1);
          }
        }
        this.filterChange("filterAgain", "filterAgain")
      }
    }
  }
}
