class Solution:
    def suggestedProducts(self, products: List[str], searchWord: str) -> List[List[str]]:
        products = sorted(products)
        results = []
        for i in range(len(searchWord)):
            tempFound = []
            removes = []
            for product in products:
                if len(product) > i and product[i] == searchWord[i]:
                    if len(tempFound) < 3:
                        tempFound.append(product)
                else:
                    removes.append(product)

            for item in removes:
                products.remove(item)

            results.append(tempFound)

        return results
